/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Core.Data;
using BaseEAM.Core.Domain;
using BaseEAM.Core.Domain.Security;
using BaseEAM.Core.WebApi;
using BaseEAM.Core.WebApi.Security;
using BaseEAM.WebApi.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BaseEAM.WebApi.Security
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class WebApiAuthenticateAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected HmacAuthentication _hmac = new HmacAuthentication();

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var result = HmacResult.FailedForUnknownReason;
            var cacheControllingData = WebApiCachingControllingData.Data();
            var now = DateTime.Now;
            User user = null;

            try
            {
                result = IsAuthenticated(actionContext, now, cacheControllingData, out user);
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                Debug.WriteLine(exc.Message);
            }

            if (result == HmacResult.Success)
            {
                // inform core about the authentication. note you cannot use IWorkContext.set_Currentuser here.
                HttpContext.Current.User = new BaseEamPrincipal(user, HmacAuthentication.Scheme1);

                var response = HttpContext.Current.Response;

                response.AddHeader(WebApiGlobal.Header.Date, now.ToString("o"));
                response.AddHeader(WebApiGlobal.Header.UserId, user.Id.ToString());

                response.Cache.SetCacheability(HttpCacheability.NoCache);
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

                var headers = actionContext.Response.Headers;

                var scheme = _hmac.GetWwwAuthenticateScheme(actionContext.Request.Headers.Authorization.Scheme);
                headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(scheme));     // see RFC-2616

                headers.Add(WebApiGlobal.Header.Date, now.ToString("o"));
                headers.Add(WebApiGlobal.Header.HmacResultId, ((int)result).ToString());
                headers.Add(WebApiGlobal.Header.HmacResultDescription, result.ToString());

                //if (cacheControllingData.LogUnauthorized)
                //    LogUnauthorized(actionContext, result, user);
            }
        }

        /// <remarks>we should never get here... just for security reason</remarks>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var message = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            throw new HttpResponseException(message);
        }

        protected string CreateContentMd5Hash(HttpRequestMessage request)
        {
            if (request != null && request.Content != null)
            {
                byte[] contentBytes = request.Content.ReadAsByteArrayAsync().Result;

                if (contentBytes != null && contentBytes.Length > 0)
                    return _hmac.CreateContentMd5Hash(contentBytes);
            }
            return "";
        }

        protected virtual User GetUser(string publicKey)
        {
            User user = null;
            try
            {
                user = WebApiEngineContext.Resolve<IRepository<User>>().GetAll().Where(u => u.PublicKey == publicKey).FirstOrDefault();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.StackTrace);
                Debug.WriteLine(exc.Message);
            }
            return user;
        }

        protected virtual HmacResult IsAuthenticated(HttpActionContext actionContext, DateTime now, WebApiControllingCacheData cacheControllingData, out User user)
        {
            user = null;

            var request = HttpContext.Current.Request;
            DateTime headDateTime;

            if (request == null)
                return HmacResult.FailedForUnknownReason;

            string headContentMd5 = request.Headers["Content-Md5"] ?? request.Headers["Content-MD5"];
            string headTimestamp = request.Headers[WebApiGlobal.Header.Date];
            string headPublicKey = request.Headers[WebApiGlobal.Header.PublicKey];
            string scheme = actionContext.Request.Headers.Authorization.Scheme;
            string signatureConsumer = actionContext.Request.Headers.Authorization.Parameter;

            if (string.IsNullOrWhiteSpace(headPublicKey))
                return HmacResult.UserInvalid;

            if (!_hmac.IsAuthorizationHeaderValid(scheme, signatureConsumer))
                return HmacResult.InvalidAuthorizationHeader;

            if (!_hmac.ParseTimestamp(headTimestamp, out headDateTime))
                return HmacResult.InvalidTimestamp;

            //int maxMinutes = (cacheControllingData.ValidMinutePeriod <= 0 ? WebApiGlobal.DefaultTimePeriodMinutes : cacheControllingData.ValidMinutePeriod);

            //if (Math.Abs((headDateTime - now).TotalMinutes) > maxMinutes)
            //    return HmacResult.TimestampOutOfPeriod;

            var apiUser = GetUser(headPublicKey);
            if (apiUser == null)
                return HmacResult.UserUnknown;

            if (!apiUser.Active || apiUser.IsDeleted)
                return HmacResult.UserIsInactive;

            //if (!HasPermission(actionContext, apiUser))
            //    return HmacResult.UserHasNoPermission;

            if (!apiUser.WebApiEnabled)
                return HmacResult.UserDisabled;

            //if (!cacheControllingData.NoRequestTimestampValidation && apiUser.LastApiRequest.HasValue && headDateTime <= apiUser.LastApiRequest.Value)
            //    return HmacResult.TimestampOlderThanLastRequest;
            
            var context = new WebApiRequestContext
            {
                HttpMethod = request.HttpMethod,
                HttpAcceptType = request.Headers["Accept"],
                PublicKey = headPublicKey,
                SecretKey = apiUser.SecretKey,
                Url = HttpUtility.UrlDecode(request.Url.AbsoluteUri.ToLower())
            };

            //string contentMd5 = CreateContentMd5Hash(actionContext.Request);

            //if (!string.IsNullOrWhiteSpace(headContentMd5) && headContentMd5 != contentMd5)
            //    return HmacResult.ContentMd5NotMatching;

            //string messageRepresentation = _hmac.CreateMessageRepresentation(context, contentMd5, headTimestamp);

            //if (string.IsNullOrEmpty(messageRepresentation))
            //    return HmacResult.MissingMessageRepresentationParameter;

            //string signatureProvider = _hmac.CreateSignature(apiUser.SecretKey, messageRepresentation);

            //if (signatureProvider != signatureConsumer)
            //{
            //    if (cacheControllingData.AllowEmptyMd5Hash)
            //    {
            //        messageRepresentation = _hmac.CreateMessageRepresentation(context, null, headTimestamp);

            //        signatureProvider = _hmac.CreateSignature(apiUser.SecretKey, messageRepresentation);

            //        if (signatureProvider != signatureConsumer)
            //            return HmacResult.InvalidSignature;
            //    }
            //    else
            //    {
            //        return HmacResult.InvalidSignature;
            //    }
            //}

            //var headers = HttpContext.Current.Response.Headers;
            //headers.Add(ApiHeaderName.LastRequest, apiUser.LastRequest.HasValue ? apiUser.LastRequest.Value.ToString("o") : "");
            
            apiUser.LastApiRequest = headDateTime;
            user = apiUser;
            return HmacResult.Success;
        }
    }
}
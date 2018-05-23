/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace BaseEAM.WebApi.Framework
{
    public static class WebApiExtension
    {
        private static MethodInfo _createResponse = InitCreateResponse();

        private static MethodInfo InitCreateResponse()
        {
            Expression<Func<HttpRequestMessage, HttpResponseMessage>> expr = (request) => request.CreateResponse<object>(HttpStatusCode.OK, default(object));

            return (expr.Body as MethodCallExpression).Method.GetGenericMethodDefinition();
        }

        /// <remarks>https://gist.github.com/raghuramn/5084608</remarks>
        public static HttpResponseMessage CreateResponse(this HttpRequestMessage request, HttpStatusCode status, Type type, object value)
        {
            return _createResponse.MakeGenericMethod(type).Invoke(null, new[] { request, status, value }) as HttpResponseMessage;
        }

        public static HttpResponseException ExceptionUnauthorized(this ApiController apiController, string message)
        {
            return new HttpResponseException(apiController.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message));
        }

        public static HttpResponseException ExceptionInvalidModelState(this ApiController apiController)
        {
            return new HttpResponseException(apiController.Request.CreateErrorResponse(HttpStatusCode.BadRequest, apiController.ModelState));
        }
        public static HttpResponseException ExceptionBadRequest(this ApiController apiController, string message)
        {
            return new HttpResponseException(apiController.Request.CreateErrorResponse(HttpStatusCode.BadRequest, message));
        }
        public static HttpResponseException ExceptionNotImplemented(this ApiController apiController)
        {
            return new HttpResponseException(HttpStatusCode.NotImplemented);
        }
        public static HttpResponseException ExceptionForbidden(this ApiController apiController)
        {
            return new HttpResponseException(HttpStatusCode.Forbidden);
        }
        public static HttpResponseException ExceptionUnsupportedMediaType(this ApiController apiController)
        {
            return new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        public static HttpResponseException ExceptionNotFound(this ApiController apiController, string message)
        {
            return new HttpResponseException(apiController.Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
        }
        public static HttpResponseException ExceptionInternalServerError(this ApiController apiController, Exception exc)
        {
            return new HttpResponseException(apiController.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exc));
        }
    }
}
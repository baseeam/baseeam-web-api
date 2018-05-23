/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace BaseEAM.WebApi.Framework
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "InternalServerError"
            };

            context.Result = new UnhandledExceptionResult(context.Request, result);
        }

        public class UnhandledExceptionResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public UnhandledExceptionResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }
    }
}
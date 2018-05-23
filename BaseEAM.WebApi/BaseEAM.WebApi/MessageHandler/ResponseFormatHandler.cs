/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BaseEAM.WebApi.MessageHandler
{
    public class ResponseFormatHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Call the inner handler.
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
using GreenTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GreenTrack.Handlers
{
    public class AuthenticatedHttpClientHandler:DelegatingHandler
    {
        private readonly SessionService _sessionService;
        public AuthenticatedHttpClientHandler(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _sessionService.Token;
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}

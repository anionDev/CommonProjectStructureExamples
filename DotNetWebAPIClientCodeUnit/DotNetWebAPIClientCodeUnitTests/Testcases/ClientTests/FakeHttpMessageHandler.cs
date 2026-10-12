using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetWebAPIClientCodeUnit.Tests.Testcases.ClientTests
{
    /// <summary>
    /// A <see cref="HttpClientHandler"/>-fake which returns a fixed response instead of performing a real HTTP-call.
    /// It is injected via <see cref="GRYLibrary.Core.APIClient.IGenericAPIClientConfiguration.HttpClientHandler"/> so
    /// that <see cref="DotNetWebAPIClientCodeUnit.Core.DotNetWebAPIClient"/> can be tested without a running
    /// DotNetWebAPICodeUnit-instance. It also captures the requested <see cref="Uri"/> so that a test can assert
    /// which route was built.
    /// </summary>
    internal sealed class FakeHttpMessageHandler : HttpClientHandler
    {
        private readonly HttpStatusCode _StatusCode;
        private readonly string _ResponseContent;

        public Uri LastRequestUri { get; private set; }

        public FakeHttpMessageHandler(HttpStatusCode statusCode, string responseContent)
        {
            this._StatusCode = statusCode;
            this._ResponseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.LastRequestUri = request.RequestUri;
            HttpResponseMessage response = new HttpResponseMessage(this._StatusCode)
            {
                Content = new StringContent(this._ResponseContent)
            };
            return Task.FromResult(response);
        }
    }
}

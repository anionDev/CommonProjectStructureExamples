using DotNetWebAPIClientCodeUnit.Core;
using GRYLibrary.Core.APIClient;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;

namespace DotNetWebAPIClientCodeUnit.Tests.Testcases.ClientTests
{
    [TestClass]
    public class DotNetWebAPIClientTests
    {
        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void ConstructorTest()
        {
            DotNetWebAPIClient _ = new DotNetWebAPIClient(default); //expect no exception
        }

        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void Add_WithPositiveDecimals_ReturnsSumParsedFromServerResponse()
        {
            // Arrange
            FakeHttpMessageHandler handler = new FakeHttpMessageHandler(HttpStatusCode.OK, "5.5");
            GenericAPIClientConfiguration configuration = new GenericAPIClientConfiguration
            {
                APIAddress = "http://fake-host",
                HttpClientHandler = handler
            };
            using DotNetWebAPIClient client = new DotNetWebAPIClient(configuration);

            // Act
            decimal actual = client.Add(2.5m, 3m);

            // Assert
            Assert.AreEqual(5.5m, actual);
            Assert.AreEqual("http://fake-host/API/V1/ExampleController/Calculator/Add/?parameter1=2.5&parameter2=3.0", handler.LastRequestUri.ToString());
        }

        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void Add_WithNegativeAndTrailingZeroDecimals_BuildsInvariantCultureFormattedRoute()
        {
            // Arrange
            FakeHttpMessageHandler handler = new FakeHttpMessageHandler(HttpStatusCode.OK, "1.5");
            GenericAPIClientConfiguration configuration = new GenericAPIClientConfiguration
            {
                APIAddress = "http://fake-host",
                HttpClientHandler = handler
            };
            using DotNetWebAPIClient client = new DotNetWebAPIClient(configuration);

            // Act
            client.Add(-1.50m, 3.00m);

            // Assert
            Assert.AreEqual("http://fake-host/API/V1/ExampleController/Calculator/Add/?parameter1=-1.5&parameter2=3.0", handler.LastRequestUri.ToString());
        }

        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void Add_WhenServerRespondsWithErrorStatusCode_ThrowsAggregateExceptionWrappingHttpRequestException()
        {
            // Arrange
            // DotNetWebAPIClient.Add bridges the underlying async HTTP-call to a synchronous call via
            // GRYLibrary's "WaitAndGetResult", which uses Task.Wait() internally. A failing HTTP-call therefore
            // does not surface as a plain HttpRequestException but as an AggregateException wrapping it.
            FakeHttpMessageHandler handler = new FakeHttpMessageHandler(HttpStatusCode.InternalServerError, string.Empty);
            GenericAPIClientConfiguration configuration = new GenericAPIClientConfiguration
            {
                APIAddress = "http://fake-host",
                HttpClientHandler = handler
            };
            using DotNetWebAPIClient client = new DotNetWebAPIClient(configuration);

            // Act
            AggregateException actual = Assert.ThrowsExactly<AggregateException>(() => client.Add(1m, 2m));

            // Assert
            Assert.IsInstanceOfType<HttpRequestException>(actual.InnerException);
        }
    }
}

using CCOT.DataCollectorClient.Core;
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.GenericAPIClient;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPIClientCodeUnit.Tests.Testcases.Integration
{
    /// <summary>
    /// Ensures that the client and server can communicate in sense of serialize/deserialize of request/response without exceptions, correct route, etc.
    /// </summary>
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.EndToEndTest))]
        public void AddTest()
        {
            // arrange
            string apiKey = default;
            using TestServer testServer = new TestServer(ClientTests.Utilities.GetTestServerBinary(), apiKey);
            GenericAPIClientConfiguration settings = new GenericAPIClientConfiguration()
            {
                APIAddress = $"http://127.0.0.1:{HTTP.DefaultPort}",
                APIKey = apiKey
            };
            decimal input1 = 2.5m;
            decimal input2 = 3m;
            decimal expected = 5.5m;
            DotNetWebAPIClient client = new DotNetWebAPIClient(settings);

            // act
            decimal actual = client.Add(input1, input2);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

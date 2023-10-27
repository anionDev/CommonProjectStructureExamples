using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.GenericAPIClient;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCOT.DataCollectorClient.Tests.Testcases.Services
{
    /// <summary>
    /// Ensures that the client and server can communicate in sense of serialize/deserialize of request/sponse without exceptions, correct route, etc.
    /// </summary>
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.IntegrationTest))]
        public void AddTest()
        {
            // arrange
            string apiKey = default;
            using TestServer testServer = new TestServer(TestUtilities.Utilities.GetTestServerBinary(), apiKey);
            GenericAPIClientConfiguration settings = new GenericAPIClientConfiguration()
            {
                APIAddress = $"http://localhost:{HTTP.DefaultPort}",
                APIKey = apiKey
            };
            decimal input1 = 2;
            decimal input2 = 3;
            decimal expected = 5;
            Core.DotNetWebAPIClient client = new Core.DotNetWebAPIClient(settings); 

            // act
            decimal actual = client.Add(input1, input2);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

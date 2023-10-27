using GRYLibrary.Core.Miscellaneous;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCOT.DataCollectorClient.Tests.Testcases.Services
{
    [TestClass]
    public class DotNetWebAPIClientTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void ConstructorTest()
        {
            Core.DotNetWebAPIClient _ = new Core.DotNetWebAPIClient(default); //expect no exception
        }
    }
}

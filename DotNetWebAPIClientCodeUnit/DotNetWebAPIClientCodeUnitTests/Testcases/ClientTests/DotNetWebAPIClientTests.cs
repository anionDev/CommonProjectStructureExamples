using DotNetWebAPIClientCodeUnit.Core;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPIClientCodeUnit.Tests.Testcases.ClientTests
{
    [TestClass]
    public class DotNetWebAPIClientTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void ConstructorTest()
        {
            DotNetWebAPIClient _ = new DotNetWebAPIClient(default); //expect no exception
        }
    }
}

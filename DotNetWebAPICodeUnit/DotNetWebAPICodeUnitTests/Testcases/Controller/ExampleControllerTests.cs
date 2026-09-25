using DotNetWebAPICodeUnit.Core.Controller;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.Logging.GRYLogger;
using GRYLibrary.Core.Misc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Controller
{
    [TestClass]
    public class ExampleControllerTests
    {
        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void TestSomeFunction()
        {
            // arrange
            IMathService someService = new MathService();
            ExampleController controller = new ExampleController(someService, new ServerLog(new GRYLogConfiguration(true), System.IO.Path.GetTempPath()));
            decimal parameter1 = 2.5m;
            decimal parameter2 = 3m;
            decimal expectedResultValue = 5.5m;

            // act
            IActionResult actualResult = controller.Calculate("Add", parameter1, parameter2);

            // assert
            Assert.IsTrue(actualResult is OkObjectResult);
            decimal actualResultValue = (decimal)(actualResult as OkObjectResult).Value;
            Assert.AreEqual(expectedResultValue, actualResultValue);
        }
    }
}

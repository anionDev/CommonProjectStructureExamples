using DotNetWebAPICodeUnit.Core.Controller;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.GeneralPurposeLogger;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotNetWebAPICodeUnit.Tests
{
    [TestClass]
    public class MyAPIControllerTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestSomeFunction()
        {
            // arrange
            MyAPIController controller = new MyAPIController(Mock.Of<ISomeService>(), GeneralLogger.NoLog());
            string parameter1 = "parameter1";
            int parameter2 = 2;
            int parameter3 = 3;
            int expectedResult = 5;

            // act
            IActionResult actualResult = controller.SomeFunction(parameter1, parameter2, parameter3);

            // assert
            Assert.IsTrue(actualResult is OkObjectResult);
            int acturalResultObject = (int)(actualResult as OkObjectResult).Value;
            Assert.AreEqual(expectedResult, acturalResultObject);
        }
    }
}

using DotNetWebAPICodeUnit.Core.Controller;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.GeneralPurposeLogger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DotNetWebAPICodeUnit.Tests
{
    [TestClass]
    public class MyAPIControllerTests
    {
        [TestMethod]
        public void TestSomeFunction()
        {
            // arrange
            MyAPIController controller = new MyAPIController(Mock.Of<ISomeService>(), Mock.Of<IGeneralLogger>());
            string parameter1 = "parameter1";
            int parameter2 = 2;
            int parameter3 = 3;
            int expectedResult = 5;

            // act
            var actualResult = controller.SomeFunction(parameter1, parameter2, parameter3);

            // assert
            Assert.IsTrue(actualResult is OkObjectResult);
            var acturalResultObject = (int)(actualResult as OkObjectResult).Value;
            Assert.AreEqual(expectedResult, acturalResultObject);
        }
    }
}

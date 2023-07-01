using DotNetConsoleCodeUnit.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetConsoleCodeUnit.Tests.Testcases
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void TestXSDValidator1()
        {
            // arrange
            ulong a = 2;
            ulong b = 3;
            ulong expectedResult = 5;

            // act
            ulong actualResult = Utilities.Add(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
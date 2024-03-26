using GRYLibrary.Core.Miscellaneous;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities = DotNetConsoleCodeUnit.Core.Utilities;

namespace DotNetConsoleCodeUnit.Tests.Testcases
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
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
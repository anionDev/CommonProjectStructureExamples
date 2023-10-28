using GRYLibrary.Core.Miscellaneous;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities = DotNetLibraryCodeUnit.Core.Utilities;

namespace DotNetLibraryCodeUnit.Tests.Testcases
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestXSDValidator1()
        {
            // arrange
            decimal a = 3.5m;
            decimal b = 2m;
            decimal expectedResult = 5.5m;

            // act
            decimal actualResult = Utilities.Add(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
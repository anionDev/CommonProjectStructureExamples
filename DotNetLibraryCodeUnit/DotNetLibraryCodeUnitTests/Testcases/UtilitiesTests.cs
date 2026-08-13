using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities = DotNetLibraryCodeUnit.Core.Miscellaneous.Utilities;

namespace DotNetLibraryCodeUnit.Tests.Testcases
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void AddTest()
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

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void SubTest()
        {
            // arrange
            decimal a = 3.5m;
            decimal b = 2m;
            decimal expectedResult = 1.5m;

            // act
            decimal actualResult = Utilities.Sub(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void MulTest()
        {
            // arrange
            decimal a = 3.5m;
            decimal b = 2m;
            decimal expectedResult = 7m;

            // act
            decimal actualResult = Utilities.Mul(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void Divtest()
        {
            // arrange
            decimal a = 3.5m;
            decimal b = 2m;
            decimal expectedResult = 1.75m;

            // act
            decimal actualResult = Utilities.Div(a, b);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
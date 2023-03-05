using DotNetLibraryCodeUnit.Core.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetLibraryCodeUnit.Tests.Testcases.Components
{
    [TestClass]
    public class FooTests
    {
        [TestMethod]
        public void TestAdd()
        {
            // arrange
            int a = 1;
            int b = 2;
            int expected = 3;

            // act
            int actual = Foo.Add(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestSub()
        {
            // arrange
            int a = 5;
            int b = 2;
            int expected = 3;

            // act
            int actual = Foo.Sub(a, b);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}

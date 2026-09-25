using GRYLibrary.Core.APIServer.ConcreteEnvironments;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities = DotNetConsoleCodeUnit.Core.Utilities;

namespace DotNetConsoleCodeUnit.Tests.Testcases
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
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

        [TestMethod]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public void GetEnvironmentTargetTypeReturnsInstanceMatchingActiveBuildConfiguration()
        {
            // arrange
            // The expected value is resolved with the same conditional-compilation-symbols as the
            // implementation: the contract of GetEnvironmentTargetType is to return the singleton which
            // corresponds to the configuration (Development/QualityCheck/Productive) this assembly was
            // compiled with, so the expectation has to be derived the same way.
#if Development
            GRYEnvironment expectedResult = Development.Instance;
#elif QualityCheck
            GRYEnvironment expectedResult = QualityCheck.Instance;
#elif Productive
            GRYEnvironment expectedResult = Productive.Instance;
#else
            GRYEnvironment expectedResult = null;
#endif

            // act
            GRYEnvironment actualResult = Utilities.GetEnvironmentTargetType();

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
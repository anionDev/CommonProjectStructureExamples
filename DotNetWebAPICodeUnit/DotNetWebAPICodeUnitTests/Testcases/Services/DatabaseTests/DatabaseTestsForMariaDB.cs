using DotNetWebAPICodeUnit.Tests.TestUtilities;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.DatabaseTests
{
    [TestClass]
    public class DatabaseTestsForMariaDB : DatabaseTestsBase
    {
        private DatabaseTestFrameworkForMariaDB? _DatabaseFramework;

        [TestInitialize]
        public void TestInitialize()
        {
            this._DatabaseFramework = DotNetWebAPICodeUnit.Tests.TestUtilities.Utilities.GetDatabaseTestFrameworkForMariaDB();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._DatabaseFramework?.Dispose();
            this._DatabaseFramework = null;
        }

        protected override DatabaseTestFrameworkTemplate GetDatabaseTestFramework()
        {
            return this._DatabaseFramework!;
        }

        [TestMethod(DisplayName = nameof(AllMigrationsAreWorkingTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void AllMigrationsAreWorkingTest()
        {
            this.AllMigrationsAreWorking();
        }

        [TestMethod(DisplayName = nameof(MigrationsAreAppliedOnlyOnceTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void MigrationsAreAppliedOnlyOnceTest()
        {
            this.MigrationsAreAppliedOnlyOnce();
        }
    }
}

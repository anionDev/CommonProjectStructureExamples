using DotNetWebAPICodeUnit.Tests.TestUtilities;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.PersistenceTests
{
    /// <summary>Runs the testcases of the persistence against MariaDB. These are integration-tests, because they need a running database.</summary>
    [TestClass]
    public class PersistenceTestsForMariaDB : PersistenceTestsBaseForDatabase
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

        [TestMethod(DisplayName = nameof(CreateAndGetCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void CreateAndGetCustomerTest()
        {
            this.CreateAndGetCustomer();
        }

        [TestMethod(DisplayName = nameof(GetAllCustomersTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void GetAllCustomersTest()
        {
            this.GetAllCustomers();
        }

        [TestMethod(DisplayName = nameof(UpdateCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void UpdateCustomerTest()
        {
            this.UpdateCustomer();
        }

        [TestMethod(DisplayName = nameof(RemoveCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void RemoveCustomerTest()
        {
            this.RemoveCustomer();
        }

        [TestMethod(DisplayName = nameof(GetCustomerWhichDoesNotExistThrowsTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.IntegrationTest))]
        public override void GetCustomerWhichDoesNotExistThrowsTest()
        {
            this.GetCustomerWhichDoesNotExistThrows();
        }
    }
}

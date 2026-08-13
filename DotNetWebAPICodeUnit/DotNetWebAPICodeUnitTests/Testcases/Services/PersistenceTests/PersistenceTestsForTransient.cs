using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.PersistenceTests
{
    /// <summary>Runs the testcases of the persistence against the implementation which keeps the data in memory. These are unit-tests, because they need nothing but the process itself.</summary>
    [TestClass]
    public class PersistenceTestsForTransient : PersistenceTestsBase
    {
        protected override IPersistence GetPersistence()
        {
            return DotNetWebAPICodeUnit.Tests.TestUtilities.Utilities.GetTransientPersistence();
        }

        [TestMethod(DisplayName = nameof(CreateAndGetCustomerTest))]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public override void CreateAndGetCustomerTest()
        {
            this.CreateAndGetCustomer();
        }

        [TestMethod(DisplayName = nameof(GetAllCustomersTest))]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public override void GetAllCustomersTest()
        {
            this.GetAllCustomers();
        }

        [TestMethod(DisplayName = nameof(UpdateCustomerTest))]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public override void UpdateCustomerTest()
        {
            this.UpdateCustomer();
        }

        [TestMethod(DisplayName = nameof(RemoveCustomerTest))]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public override void RemoveCustomerTest()
        {
            this.RemoveCustomer();
        }

        [TestMethod(DisplayName = nameof(GetCustomerWhichDoesNotExistThrowsTest))]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public override void GetCustomerWhichDoesNotExistThrowsTest()
        {
            this.GetCustomerWhichDoesNotExistThrows();
        }
    }
}

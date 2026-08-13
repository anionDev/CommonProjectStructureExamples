using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.Exceptions;
using GRYLibrary.Core.Logging.GRYLogger;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services
{
    /// <summary>
    /// Testcases for the business-rules. They run against the transient persistence, because the rules are the same
    /// regardless of where the data is stored, and the storing itself is tested by the testcases of the persistence.
    /// </summary>
    [TestClass]
    public class BusinessLogicServiceTests
    {
        private static IBusinessLogicService GetBusinessLogicService(out IPersistence persistence)
        {
            persistence = DotNetWebAPICodeUnit.Tests.TestUtilities.Utilities.GetTransientPersistence();
            IServerLog log = new ServerLog(new GRYLogConfiguration(true), Path.GetTempPath());
            return new BusinessLogicService(persistence, log);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestCreateCustomerStoresTheCustomer()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out IPersistence persistence);

            // act
            int id = businessLogicService.CreateCustomer("Example customer", "customer@example.com");

            // assert
            Assert.AreEqual("Example customer", persistence.GetCustomer(id).Name);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestCreateCustomerAssignsAnUnusedId()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);

            // act
            int firstId = businessLogicService.CreateCustomer("First customer", "first@example.com");
            int secondId = businessLogicService.CreateCustomer("Second customer", "second@example.com");

            // assert
            Assert.AreNotEqual(firstId, secondId);
            Assert.AreEqual(2, businessLogicService.GetAllCustomers().Count);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestCreateCustomerWithEmptyNameIsRejected()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);

            // act & assert
            Assert.ThrowsExactly<BadRequestException>(() => businessLogicService.CreateCustomer("   ", "customer@example.com"));
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestCreateCustomerWithInvalidEmailAddressIsRejected()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);

            // act & assert
            Assert.ThrowsExactly<BadRequestException>(() => businessLogicService.CreateCustomer("Example customer", "not-an-email-address"));
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestUpdateCustomerAppliesTheNewValues()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);
            int id = businessLogicService.CreateCustomer("Old name", "old@example.com");

            // act
            businessLogicService.UpdateCustomer(new Customer() { Id = id, Name = "New name", ContactEmailAddress = "new@example.com" });

            // assert
            Assert.AreEqual("New name", businessLogicService.GetCustomer(id).Name);
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestUpdateCustomerWhichDoesNotExistIsRejected()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);

            // act & assert
            // Without the check in the business-logic this would silently create a customer, because the
            // persistence stores what it gets.
            Assert.ThrowsExactly<KeyNotFoundException>(() => businessLogicService.UpdateCustomer(new Customer() { Id = 42, Name = "Example customer", ContactEmailAddress = "customer@example.com" }));
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestRemoveCustomer()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);
            int id = businessLogicService.CreateCustomer("Example customer", "customer@example.com");

            // act
            businessLogicService.RemoveCustomer(id);

            // assert
            Assert.IsEmpty(businessLogicService.GetAllCustomers());
        }

        [TestMethod]
        [TestProperty(nameof(TestKind), nameof(TestKind.UnitTest))]
        public void TestRemoveCustomerWhichDoesNotExistIsRejected()
        {
            // arrange
            IBusinessLogicService businessLogicService = GetBusinessLogicService(out _);

            // act & assert
            Assert.ThrowsExactly<KeyNotFoundException>(() => businessLogicService.RemoveCustomer(42));
        }
    }
}

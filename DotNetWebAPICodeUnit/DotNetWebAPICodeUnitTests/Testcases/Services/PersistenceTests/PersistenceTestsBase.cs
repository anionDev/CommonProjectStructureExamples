using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using DotNetWebAPICodeUnit.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.PersistenceTests
{
    /// <summary>
    /// Testcases which every implementation of the persistence must fulfill. They are written against the interface and
    /// not against one implementation, so that the transient one and the database-backed ones really behave the same.
    /// The classes which inherit from this one only add which implementation is tested.
    /// </summary>
    public abstract class PersistenceTestsBase
    {
        /// <summary>Returns the persistence which is tested. It is expected to be empty.</summary>
        protected abstract IPersistence GetPersistence();

        public abstract void CreateAndGetCustomerTest();

        protected void CreateAndGetCustomer()
        {
            // arrange
            IPersistence persistence = this.GetPersistence();
            Customer customer = new Customer() { Id = 1, Name = "Example customer", ContactEmailAddress = "customer@example.com" };

            // act
            persistence.CreateCustomer(customer);

            // assert
            Customer loadedCustomer = persistence.GetCustomer(1);
            Assert.AreEqual(customer.Id, loadedCustomer.Id);
            Assert.AreEqual(customer.Name, loadedCustomer.Name);
            Assert.AreEqual(customer.ContactEmailAddress, loadedCustomer.ContactEmailAddress);
        }

        public abstract void GetAllCustomersTest();

        protected void GetAllCustomers()
        {
            // arrange
            IPersistence persistence = this.GetPersistence();
            persistence.CreateCustomer(new Customer() { Id = 1, Name = "First customer", ContactEmailAddress = "first@example.com" });
            persistence.CreateCustomer(new Customer() { Id = 2, Name = "Second customer", ContactEmailAddress = "second@example.com" });

            // act
            ISet<Customer> customers = persistence.GetAllCustomers();

            // assert
            Assert.AreEqual(2, customers.Count);
            Assert.IsTrue(customers.Any(customer => customer.Name == "First customer"));
            Assert.IsTrue(customers.Any(customer => customer.Name == "Second customer"));
        }

        public abstract void UpdateCustomerTest();

        protected void UpdateCustomer()
        {
            // arrange
            IPersistence persistence = this.GetPersistence();
            persistence.CreateCustomer(new Customer() { Id = 1, Name = "Old name", ContactEmailAddress = "old@example.com" });

            // act
            persistence.UpdateCustomer(new Customer() { Id = 1, Name = "New name", ContactEmailAddress = "new@example.com" });

            // assert
            Customer loadedCustomer = persistence.GetCustomer(1);
            Assert.AreEqual("New name", loadedCustomer.Name);
            Assert.AreEqual("new@example.com", loadedCustomer.ContactEmailAddress);
            Assert.AreEqual(1, persistence.GetAllCustomers().Count);
        }

        public abstract void RemoveCustomerTest();

        protected void RemoveCustomer()
        {
            // arrange
            IPersistence persistence = this.GetPersistence();
            persistence.CreateCustomer(new Customer() { Id = 1, Name = "Example customer", ContactEmailAddress = "customer@example.com" });

            // act
            persistence.RemoveCustomer(1);

            // assert
            Assert.IsEmpty(persistence.GetAllCustomers());
        }

        public abstract void GetCustomerWhichDoesNotExistThrowsTest();

        protected void GetCustomerWhichDoesNotExistThrows()
        {
            // arrange
            IPersistence persistence = this.GetPersistence();

            // act & assert
            Assert.ThrowsExactly<KeyNotFoundException>(() => persistence.GetCustomer(42));
        }
    }
}

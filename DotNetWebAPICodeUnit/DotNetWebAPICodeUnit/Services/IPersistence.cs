using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using GRYLibrary.Core.APIServer.Services;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Stores the data of this codeunit. An implementation stores what it gets and does not decide what is allowed; that is what the business-logic-service is for.</summary>
    public interface IPersistence : IExternalService
    {
        /// <summary>Returns all customers.</summary>
        public ISet<Customer> GetAllCustomers();

        /// <summary>Returns the customer with the given id.</summary>
        /// <exception cref="KeyNotFoundException">Thrown when there is no customer with that id.</exception>
        public Customer GetCustomer(int customerId);

        /// <summary>Stores the given customer as a new one.</summary>
        public void CreateCustomer(Customer customer);

        /// <summary>Applies the values of the given customer to the customer which has its id.</summary>
        public void UpdateCustomer(Customer customer);

        /// <summary>Removes the customer with the given id.</summary>
        public void RemoveCustomer(int customerId);

        /// <summary>Removes all data. This exists for the testcases, which need a defined state.</summary>
        public void Reset();
    }
}

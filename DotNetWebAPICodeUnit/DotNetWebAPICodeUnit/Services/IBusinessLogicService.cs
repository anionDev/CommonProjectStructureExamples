using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>
    /// Contains the business-rules of this codeunit. The controllers only translate between http and this service and
    /// the persistence only stores what it gets, so this is the place where it is decided what is allowed and what is not.
    /// </summary>
    public interface IBusinessLogicService
    {
        /// <summary>Creates a new customer.</summary>
        /// <param name="name">The name of the customer. It must neither be empty nor consist of whitespace only.</param>
        /// <param name="contactEmailAddress">The email-address under which the customer is contacted.</param>
        /// <returns>The id which the new customer got.</returns>
        public int CreateCustomer(string name, string contactEmailAddress);

        /// <summary>Returns the customer with the given id.</summary>
        /// <param name="customerId">The id of the customer.</param>
        public Customer GetCustomer(int customerId);

        /// <summary>Returns all customers.</summary>
        public ISet<Customer> GetAllCustomers();

        /// <summary>Applies the values of the given customer to the customer which has its id.</summary>
        /// <param name="customer">The customer with the new values.</param>
        public void UpdateCustomer(Customer customer);

        /// <summary>Removes the customer with the given id.</summary>
        /// <param name="customerId">The id of the customer.</param>
        public void RemoveCustomer(int customerId);
    }
}

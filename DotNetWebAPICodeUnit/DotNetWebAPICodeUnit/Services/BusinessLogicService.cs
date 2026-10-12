using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.Exceptions;
using GRYLibrary.Core.Logging.GRYLogger;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <inheritdoc cref="IBusinessLogicService" />
    public class BusinessLogicService : IBusinessLogicService
    {
        private readonly IPersistence _Persistence;
        private readonly IGRYLog _Log;

        public BusinessLogicService(IPersistence persistence, IServerLog log)
        {
            this._Persistence = persistence;
            this._Log = log.Logger;
        }

        /// <inheritdoc />
        public int CreateCustomer(string name, string contactEmailAddress)
        {
            ValidateCustomerValues(name, contactEmailAddress);
            // The id is assigned here and not by the database, so the same rule applies to every database-type
            // this codeunit supports. A real product with concurrent writers uses a sequence of the database instead.
            ISet<Customer> existingCustomers = this._Persistence.GetAllCustomers();
            int newId = existingCustomers.Count == 0 ? 1 : existingCustomers.Max(customer => customer.Id) + 1;
            this._Persistence.CreateCustomer(new Customer() { Id = newId, Name = name, ContactEmailAddress = contactEmailAddress });
            this._Log.Log($"Created the customer with the id {newId}.", LogLevel.Information);
            return newId;
        }

        /// <inheritdoc />
        public Customer GetCustomer(int customerId)
        {
            return this._Persistence.GetCustomer(customerId);
        }

        /// <inheritdoc />
        public ISet<Customer> GetAllCustomers()
        {
            return this._Persistence.GetAllCustomers();
        }

        /// <inheritdoc />
        public void UpdateCustomer(Customer customer)
        {
            ValidateCustomerValues(customer.Name, customer.ContactEmailAddress);
            // Reading the customer first is what turns an update of something which does not exist into an error
            // instead of into a silent insert, because the persistence stores whatever it gets.
            this._Persistence.GetCustomer(customer.Id);
            this._Persistence.UpdateCustomer(customer);
            this._Log.Log($"Updated the customer with the id {customer.Id}.", LogLevel.Information);
        }

        /// <inheritdoc />
        public void RemoveCustomer(int customerId)
        {
            this._Persistence.GetCustomer(customerId);
            this._Persistence.RemoveCustomer(customerId);
            this._Log.Log($"Removed the customer with the id {customerId}.", LogLevel.Information);
        }

        private static void ValidateCustomerValues(string name, string contactEmailAddress)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("The name of a customer must not be empty.");
            }
            if (string.IsNullOrWhiteSpace(contactEmailAddress) || !contactEmailAddress.Contains('@'))
            {
                throw new BadRequestException($"\"{contactEmailAddress}\" is not a valid email-address.");
            }
        }
    }
}

using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Persistence which keeps the data in memory. It is used when the application runs without a database, for example while developing and in the testcases.</summary>
    public sealed class TransientPersistence : IPersistence
    {
        private readonly IDictionary<int, Customer> _Customers = new Dictionary<int, Customer>();

        /// <inheritdoc />
        public ISet<Customer> GetAllCustomers()
        {
            return this._Customers.Values.ToHashSet();
        }

        /// <inheritdoc />
        public Customer GetCustomer(int customerId)
        {
            if (!this._Customers.TryGetValue(customerId, out Customer? customer))
            {
                throw new KeyNotFoundException($"There is no customer with the id {customerId}.");
            }
            return customer;
        }

        /// <inheritdoc />
        public void CreateCustomer(Customer customer)
        {
            this._Customers[customer.Id] = customer;
        }

        /// <inheritdoc />
        public void UpdateCustomer(Customer customer)
        {
            this._Customers[customer.Id] = customer;
        }

        /// <inheritdoc />
        public void RemoveCustomer(int customerId)
        {
            this._Customers.Remove(customerId);
        }

        /// <inheritdoc />
        public void Reset()
        {
            this._Customers.Clear();
        }

        /// <inheritdoc />
        public (bool, Exception?) IsAvailable()
        {
            return (true, null);
        }

        public void Dispose()
        {
            this._Customers.Clear();
        }
    }
}

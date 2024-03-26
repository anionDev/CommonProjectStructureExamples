using DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Core.Services
{
    public class TransientPersistence : IPersistence
    {
        private readonly IDictionary<int, Customer> _Customer;
        public TransientPersistence()
        {
            this._Customer = new Dictionary<int, Customer>();
        }
        public void SetCustomer(Customer customer)
        {
            this._Customer[customer.Id] = customer;
        }

        public ISet<Customer> GetAllCustomer()
        {
            return this._Customer.Values.ToHashSet();
        }

        public Customer GetCustomer(int customerId)
        {
            return this._Customer[customerId];
        }

        public void RemoveCustomer(int customerId)
        {
            if (this._Customer.ContainsKey(customerId))
            {
                this._Customer.Remove(customerId);
            }
        }
    }
}

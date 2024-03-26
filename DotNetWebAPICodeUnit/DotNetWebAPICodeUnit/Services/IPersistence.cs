using DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Core.Services
{
    public interface IPersistence
    {
        public ISet<Customer> GetAllCustomer();
        public Customer GetCustomer(int customerId);
        public void SetCustomer(Customer customer);
        public void RemoveCustomer(int customerId);
    }
}

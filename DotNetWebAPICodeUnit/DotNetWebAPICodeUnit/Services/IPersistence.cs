using DotNetWebAPICodeUnit.Core.Database.Contexts.DatabaseContext000000.DataTypes;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Core.Services
{
    public interface IPersistence
    {
        public ISet<Customer> GetAllCustomer();
        public void AddCustomer(Customer customer);
        public void RemoveCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);  
    }
}

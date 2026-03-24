using DotNetWebAPICodeUnit.Core.Database.Contexts.DataTypes;
using GRYLibrary.Core.APIServer.Services;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Core.Services
{
    public interface IPersistence : IExternalService
    {
        public ISet<Customer> GetAllCustomer();
        public Customer GetCustomer(int customerId);
        public void SetCustomer(Customer customer);
        public void RemoveCustomer(int customerId);
    }
}

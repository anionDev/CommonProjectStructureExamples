using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using GRYLibrary.Core.Miscellaneous.Migration.Templates;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GRYLibrary.Core.Miscellaneous.Migration;
using System.Linq;
using DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001;

namespace DotNetWebAPICodeUnit.Core.Services
{
    //see https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    public class DatabasePersistence : IPersistence
    {
        private readonly DatabaseContext000001 _DatabaseContext;
        public DatabasePersistence(IGeneralLogger logger, DbContextOptions<DatabaseContext000001> options)
        {
            this._DatabaseContext = new DatabaseContext000001(options);
            SQLiteDBMigratable migratable = new SQLiteDBMigratable(logger, this.GetMigrationConfiguration(), Version3.Parse(Constants.GeneralConstants.CodeUnitVersion));
            migratable.InitializeDatabaseAndMigrateIfRequired();
        }

        public void SetCustomer(DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes.Customer customer)
        {
            this._DatabaseContext.Customer.Add(customer);
            this._DatabaseContext.SaveChanges();
        }

        public ISet<DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes.Customer> GetAllCustomer()
        {
            return this._DatabaseContext.Customer.ToHashSet();
        }

        public DotNetWebAPICodeUnit.Core.Database.Contexts.Context000001.DataTypes.Customer GetCustomer(int customerId)
        {
            return this._DatabaseContext.Customer.First(c => c.Id == customerId);
        }

        public void RemoveCustomer(int customerId)
        {
            this._DatabaseContext.Remove(this.GetCustomer(customerId));
            this._DatabaseContext.SaveChanges();
        }

        private MigrationConfiguration GetMigrationConfiguration()
        {
            var result = new MigrationConfiguration();
            //add migration-configurations if desired
            return result;
        }

        public bool IsAvailable()
        {
            return this._DatabaseContext.Database.CanConnect();
        }
    }
}

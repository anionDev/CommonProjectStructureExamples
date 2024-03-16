using DotNetWebAPICodeUnit.Core.Database.Contexts.DatabaseContext000000;
using DotNetWebAPICodeUnit.Core.Database.Contexts.DatabaseContext000000.DataTypes;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using GRYLibrary.Core.Miscellaneous.Migration.Templates;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GRYLibrary.Core.Miscellaneous.Migration;
using System;

namespace DotNetWebAPICodeUnit.Core.Services
{
    //see https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    public class DatabasePersistence : IPersistence
    {
        private readonly DatabaseContext000000 _DatabaseContext;
        public DatabasePersistence(IGeneralLogger logger, DbContextOptions<DatabaseContext000000> options)
        {
            this._DatabaseContext = new DatabaseContext000000(logger, options);
            var migratable = new SQLiteDBMigratable(logger, this.GetMigrationConfiguration(), Version3.Parse(Constants.GeneralConstants.CodeUnitVersion));
            migratable.InitializeDatabaseAndMigrateIfRequired();
        }

        private MigrationConfiguration GetMigrationConfiguration()
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public ISet<Customer> GetAllCustomer()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}

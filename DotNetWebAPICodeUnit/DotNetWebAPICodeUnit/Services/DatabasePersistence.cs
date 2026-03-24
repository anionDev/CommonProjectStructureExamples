using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using GRYLibrary.Core.APIServer.Services.Interfaces;
using DotNetWebAPICodeUnit.Core.Database.Contexts;
using GRYLibrary.Core.APIServer.Services.Trans;
using System;

namespace DotNetWebAPICodeUnit.Core.Services
{
    public sealed class DatabasePersistence : IPersistence
    {
        private readonly DatabaseContext _DatabaseContext;
        private readonly IGeneralLogger _Logger;
        private readonly ITimeService _TimeService;
        public DatabasePersistence(IGeneralLogger logger, ITimeService timeService, DbContextOptions<DatabaseContext> options, IDatabaseManager databaseManager)
        {
            this._Logger = logger;
            this._TimeService = timeService;
            this._DatabaseContext = new DatabaseContext(options, logger, timeService, databaseManager);
        }

        public void SetCustomer(Database.Contexts.DataTypes.Customer customer)
        {
            throw new NotImplementedException();
        }

        public ISet<Database.Contexts.DataTypes.Customer> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public Database.Contexts.DataTypes.Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool IsAvailable()
        {
            return this._DatabaseContext.Database.CanConnect();
        }

        public void Dispose()
        {
            this._DatabaseContext.Dispose();
        }
    }
}

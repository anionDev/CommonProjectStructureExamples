using DotNetWebAPICodeUnit.Core.Model.BusinessTypes;
using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Services.Interfaces;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.APIServer.Utilities.InitializationStates;
using GRYLibrary.Core.Logging.GRYLogger;
using System;
using System.Collections.Generic;
using System.Data.Common;
using GUtilities = GRYLibrary.Core.Misc.Utilities;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Persistence which stores the data in a database. The sql-statements come from the sql-provider of the database-interactor, so this class is independent of the concrete database-type.</summary>
    public sealed class DatabasePersistence : IInitializable, IPersistence
    {
        private static readonly object _Lock = new object();
        private readonly IDotNetWebAPICodeUnitDatabaseInteractor _Database;
        private readonly ISQLProvider _SQLProvider;
        private readonly ITimeService _TimeService;
        private readonly IGRYLog _Log;

        public InitializationState InitializationState { get; private set; }

        /// <summary>Initializes a new database-backed persistence.</summary>
        /// <param name="database">The database-interactor which executes the sql-commands.</param>
        /// <param name="timeService">The service which provides the current time. The migrator uses it to record when a migration was applied.</param>
        /// <param name="log">The logger.</param>
        public DatabasePersistence(IDotNetWebAPICodeUnitDatabaseInteractor database, ITimeService timeService, IServerLog log)
        {
            this._Database = database;
            this._SQLProvider = database.GetSQLProvider();
            this._TimeService = timeService;
            this._Log = log.Logger;
            this.InitializationState = new Uninitialized();
        }

        private void RunTransaction(string nameOfAction, params Action<DbCommand>[] actions)
        {
            lock (_Lock)
            {
                DBUtilities.RunTransaction(nameOfAction, this._Log, this._Database, true, actions);
            }
        }

        /// <inheritdoc />
        public void Initialize()
        {
            lock (_Lock)
            {
                try
                {
                    this.InitializationState = new Initializing();
                    this._Database.GetGenericDatabaseInteractor().DoAllMigrations(this._Database.GetAllMigrations(), this._TimeService);
                    this.InitializationState = new Initialized();
                }
                catch (Exception exception)
                {
                    this.InitializationState = new InitializationFailed();
                    this._Log.Log("Initialization failed", exception);
                }
            }
        }

        /// <inheritdoc />
        public void WaitUntilAvailable(TimeSpan timeSpan)
        {
            this._Database.GetGenericDatabaseInteractor().WaitUntilAvailable(timeSpan);
        }

        /// <inheritdoc />
        public void CreateCustomer(Customer customer)
        {
            this.RunTransaction(nameof(CreateCustomer), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptCreateCustomer();
                this.AddCustomerParameters(command, customer);
                command.ExecuteNonQuery();
            });
        }

        /// <inheritdoc />
        public void UpdateCustomer(Customer customer)
        {
            this.RunTransaction(nameof(UpdateCustomer), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptUpdateCustomer();
                this.AddCustomerParameters(command, customer);
                command.ExecuteNonQuery();
            });
        }

        /// <inheritdoc />
        public void RemoveCustomer(int customerId)
        {
            this.RunTransaction(nameof(RemoveCustomer), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptRemoveCustomer();
                command.Parameters.Add(this._Database.GetGenericDatabaseInteractor().GetParameter("Id", customerId));
                command.ExecuteNonQuery();
            });
        }

        /// <inheritdoc />
        public Customer GetCustomer(int customerId)
        {
            Customer? result = null;
            this.RunTransaction(nameof(GetCustomer), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptGetCustomer();
                command.Parameters.Add(this._Database.GetGenericDatabaseInteractor().GetParameter("Id", customerId));
                using (DbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = ReadCustomer(reader);
                    }
                }
            });
            if (result == null)
            {
                throw new KeyNotFoundException($"There is no customer with the id {customerId}.");
            }
            return result;
        }

        /// <inheritdoc />
        public ISet<Customer> GetAllCustomers()
        {
            HashSet<Customer> result = new HashSet<Customer>();
            this.RunTransaction(nameof(GetAllCustomers), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptGetAllCustomers();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(ReadCustomer(reader));
                    }
                }
            });
            return result;
        }

        /// <inheritdoc />
        public void Reset()
        {
            this.RunTransaction(nameof(Reset), (command) =>
            {
                command.CommandText = this._SQLProvider.GetScriptResetDatabase();
                command.ExecuteNonQuery();
            });
        }

        private void AddCustomerParameters(DbCommand command, Customer customer)
        {
            IGenericDatabaseInteractor interactor = this._Database.GetGenericDatabaseInteractor();
            command.Parameters.Add(interactor.GetParameter("Id", customer.Id));
            command.Parameters.Add(interactor.GetParameter("Name", customer.Name));
            command.Parameters.Add(interactor.GetParameter("ContactEmailAddress", customer.ContactEmailAddress));
        }

        private static Customer ReadCustomer(DbDataReader reader)
        {
            return new Customer()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                ContactEmailAddress = reader.GetString(2),
            };
        }

        /// <inheritdoc />
        public (bool, Exception?) IsAvailable()
        {
            lock (_Lock)
            {
                bool result = this._Database.GetGenericDatabaseInteractor().TryGetConnection(out _, out Exception? exception);
                return (result, exception);
            }
        }

        public void Dispose()
        {
            this._Database.GetGenericDatabaseInteractor().Dispose();
        }
    }
}

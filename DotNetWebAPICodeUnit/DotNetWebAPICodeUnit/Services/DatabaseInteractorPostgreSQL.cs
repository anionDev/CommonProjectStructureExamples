using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.Misc.Migration;
using System.Collections.Generic;
using System.Reflection;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Database-interactor for PostgreSQL. It wraps the generic interactor of the library and adds the migrations and the statements written for PostgreSQL.</summary>
    public class DatabaseInteractorPostgreSQL : IDotNetWebAPICodeUnitDatabaseInteractor
    {
        private readonly PostgreSQLDatabaseInteractor _DatabaseInteractor;
        private readonly IList<MigrationInstance> _Migrations = GRYMigrator.LoadMigrationsFromResources(Assembly.GetExecutingAssembly(), "DotNetWebAPICodeUnit.Core.Resources.Database.PostgreSQL.Migrations.");

        /// <summary>Initializes a new instance of <see cref="DatabaseInteractorPostgreSQL"/>.</summary>
        /// <param name="interactor">The generic database-interactor which gets wrapped. It is created by the dependency-injection, because it needs the connection-string and the logger of the application.</param>
        public DatabaseInteractorPostgreSQL(IGenericDatabaseInteractor interactor)
        {
            this._DatabaseInteractor = (PostgreSQLDatabaseInteractor)interactor;
        }

        /// <inheritdoc />
        public IList<MigrationInstance> GetAllMigrations()
        {
            return this._Migrations;
        }

        /// <inheritdoc />
        public IGenericDatabaseInteractor GetGenericDatabaseInteractor()
        {
            return this._DatabaseInteractor;
        }

        /// <inheritdoc />
        public ISQLProvider GetSQLProvider()
        {
            return new SQLProviderPostgreSQL();
        }

        /// <inheritdoc />
        public void SetLogConnectionAttemptErrors(bool enabled)
        {
            this._DatabaseInteractor.SetLogConnectionAttemptErrors(enabled);
        }
    }
}

using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GRYLogger;
using System;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Tests.TestUtilities
{
    /// <summary>Starts the PostgreSQL-test-service and connects to it. The task-names are the ones which are generated from the workspace-file of the repository.</summary>
    public sealed class DatabaseTestFrameworkForPostgreSQL : DatabaseTestFrameworkTemplate
    {
        public DatabaseTestFrameworkForPostgreSQL(IGRYLog log) : base(
            new DatabasePersistenceConfiguration() { DatabaseType = "PostgreSQL", DatabaseConnectionString = Utilities.GetTestPostgreSQLConnectionString() },
            Utilities.GetTestPostgreSQLDatabaseFolder(),
            Constants.GeneralConstants.RepositoryFolder,
            "LocaltestservicePostgresqlStart",
            "LocaltestservicePostgresqlStop",
            Utilities.GetResetDatabaseScript("PostgreSQL"),
            log,
            TimeSpan.FromSeconds(200),
            new HashSet<string>() { "commonprojectstructureexamples_postgresql" })
        {
        }

        public override string GetDatabaseTypeName()
        {
            return "PostgreSQL";
        }
    }
}

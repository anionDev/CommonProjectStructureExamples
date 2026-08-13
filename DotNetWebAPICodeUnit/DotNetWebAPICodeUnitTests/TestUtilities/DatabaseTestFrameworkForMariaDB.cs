using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GRYLogger;
using System;
using System.Collections.Generic;

namespace DotNetWebAPICodeUnit.Tests.TestUtilities
{
    /// <summary>Starts the MariaDB-test-service and connects to it. The task-names are the ones which are generated from the workspace-file of the repository.</summary>
    public sealed class DatabaseTestFrameworkForMariaDB : DatabaseTestFrameworkTemplate
    {
        public DatabaseTestFrameworkForMariaDB(IGRYLog log) : base(
            new DatabasePersistenceConfiguration() { DatabaseType = "MariaDB", DatabaseConnectionString = Utilities.GetTestMariaDBConnectionString() },
            Utilities.GetTestMariaDBDatabaseFolder(),
            Constants.GeneralConstants.RepositoryFolder,
            "LocaltestserviceMariadbStart",
            "LocaltestserviceMariadbStop",
            Utilities.GetResetDatabaseScript("MariaDB"),
            log,
            TimeSpan.FromSeconds(200),
            new HashSet<string>() { "commonprojectstructureexamples_mariadb" })
        {
        }

        public override string GetDatabaseTypeName()
        {
            return "MariaDB";
        }
    }
}

using DotNetWebAPICodeUnit.Core.Services;
using DotNetWebAPICodeUnit.Tests.TestUtilities.Constants;
using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using System.IO;
using System.Text;
using GUtilities = GRYLibrary.Core.Misc.Utilities;

namespace DotNetWebAPICodeUnit.Tests.TestUtilities
{
    /// <summary>Helper-functions which more than one testcase needs.</summary>
    public static class Utilities
    {
        public static string GetTestMariaDBDatabaseFolder()
        {
            return GUtilities.ResolveToFullPath($@"{GeneralConstants.RepositoryFolder}\Other\Resources\LocalTestServices\MariaDBDatabase");
        }

        public static string GetTestPostgreSQLDatabaseFolder()
        {
            return GUtilities.ResolveToFullPath($@"{GeneralConstants.RepositoryFolder}\Other\Resources\LocalTestServices\PostgreSQLDatabase");
        }

        /// <summary>Returns the statement which brings the database back to an empty state. The testcases run it before every testcase, so that no testcase depends on what another one left behind.</summary>
        /// <param name="databaseName">The name of the database-type, so "MariaDB" or "PostgreSQL".</param>
        public static string GetResetDatabaseScript(string databaseName)
        {
            string file = Path.Combine(GeneralConstants.CodeUnitFolder, "DotNetWebAPICodeUnit", "Resources", "Database", databaseName, "Statements", "ResetDatabase.sql");
            return File.ReadAllText(file, new UTF8Encoding(false));
        }

        /// <summary>
        /// Returns the host under which the test-database-container is reachable.
        /// Inside the build-container the test-process is attached to the docker-network of the test-services and reaches the
        /// container by its container-name. On the host it is reached via "localhost", because the container publishes its port.
        /// </summary>
        private static string GetTestDatabaseHost(string containerName)
        {
            bool runningInBuildContainer = System.Environment.GetEnvironmentVariable("ISRUNNINGINBUILDCONTAINER") == "true";
            return runningInBuildContainer ? containerName : "localhost";
        }

        public static string GetTestMariaDBConnectionString()
        {
            return $"Host={GetTestDatabaseHost("commonprojectstructureexamples_mariadb")};Port=3306;User ID=user;Password=pa55w0rd;Database=DotNetWebAPICodeUnitDatabase;";
        }

        public static string GetTestPostgreSQLConnectionString()
        {
            return $"Host={GetTestDatabaseHost("commonprojectstructureexamples_postgresql")};Port=5432;Username=user;Password=pa55w0rd;Database=DotNetWebAPICodeUnitDatabase;IncludeErrorDetail=true;";
        }

        public static IDatabasePersistenceConfiguration GetDatabaseConfigurationMariaDB()
        {
            return new DatabasePersistenceConfiguration()
            {
                DatabaseConnectionString = GetTestMariaDBConnectionString(),
                DatabaseType = "MariaDB",
            };
        }

        public static IDatabasePersistenceConfiguration GetDatabaseConfigurationPostgreSQL()
        {
            return new DatabasePersistenceConfiguration()
            {
                DatabaseConnectionString = GetTestPostgreSQLConnectionString(),
                DatabaseType = "PostgreSQL",
            };
        }

        public static DatabaseTestFrameworkForMariaDB GetDatabaseTestFrameworkForMariaDB()
        {
            return new DatabaseTestFrameworkForMariaDB(GeneralLogger.CreateUsingConsole());
        }

        public static DatabaseTestFrameworkForPostgreSQL GetDatabaseTestFrameworkForPostgreSQL()
        {
            return new DatabaseTestFrameworkForPostgreSQL(GeneralLogger.CreateUsingConsole());
        }

        public static TransientPersistence GetTransientPersistence()
        {
            return new TransientPersistence();
        }
    }
}

using DotNetWebAPICodeUnit.Core.Miscellaneous;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.APIServer.Services.OtherServices;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GRYLogger;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.PersistenceTests
{
    /// <summary>
    /// Runs the testcases of the persistence against a real database. The database is brought to an empty state and
    /// migrated before every testcase, so that the testcases do not depend on each other.
    /// </summary>
    public abstract class PersistenceTestsBaseForDatabase : PersistenceTestsBase
    {
        protected abstract DatabaseTestFrameworkTemplate GetDatabaseTestFramework();

        protected override IPersistence GetPersistence()
        {
            DatabaseTestFrameworkTemplate databaseTestFramework = this.GetDatabaseTestFramework();
            databaseTestFramework.ResetDatabase();
            IDotNetWebAPICodeUnitDatabaseInteractor interactor = databaseTestFramework.GenericDatabaseInteractor().Accept(new GetDatabaseInteractorVisitor());
            IServerLog log = new ServerLog(new GRYLogConfiguration(true), System.IO.Path.GetTempPath());
            DatabasePersistence result = new DatabasePersistence(interactor, new TimeService(), log);
            result.Initialize();
            return result;
        }
    }
}

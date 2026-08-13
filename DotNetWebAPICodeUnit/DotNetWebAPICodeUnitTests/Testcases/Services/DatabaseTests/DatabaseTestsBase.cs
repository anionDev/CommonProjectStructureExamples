using DotNetWebAPICodeUnit.Core.Miscellaneous;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Database;
using GRYLibrary.Core.APIServer.Services.OtherServices;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Misc.Migration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.DatabaseTests
{
    /// <summary>
    /// Testcases for the migrations of this codeunit. They run against a real database, because a migration which is
    /// only checked against a mock does not tell whether the sql it contains is accepted by the database.
    /// The concrete database-type is added by the classes which inherit from this one.
    /// </summary>
    public abstract class DatabaseTestsBase
    {
        protected abstract DatabaseTestFrameworkTemplate GetDatabaseTestFramework();

        protected DatabaseTestFrameworkTemplate GetDatabaseTestFramework(bool runMigrations)
        {
            DatabaseTestFrameworkTemplate result = this.GetDatabaseTestFramework();
            this.PrepareDatabase(result, runMigrations);
            return result;
        }

        /// <summary>Brings the database to an empty state and, if desired, applies all migrations of this codeunit.</summary>
        private void PrepareDatabase(DatabaseTestFrameworkTemplate databaseTestFramework, bool runMigrations)
        {
            databaseTestFramework.ResetDatabase();
            IGenericDatabaseInteractor databaseInteractor = databaseTestFramework.GenericDatabaseInteractor();
            Assert.IsEmpty(databaseInteractor.GetAllTableNames().ToList());
            if (runMigrations)
            {
                IDotNetWebAPICodeUnitDatabaseInteractor interactor = databaseInteractor.Accept(new GetDatabaseInteractorVisitor());
                IList<MigrationInstance> migrations = interactor.GetAllMigrations();
                Assert.IsNotEmpty(migrations);
                databaseInteractor.DoAllMigrations(migrations, new TimeService());
            }
        }

        public abstract void AllMigrationsAreWorkingTest();

        /// <summary>Applies all migrations and checks that the table of the example-businesstype exists afterwards.</summary>
        protected void AllMigrationsAreWorking()
        {
            // arrange & act
            DatabaseTestFrameworkTemplate databaseTestFramework = this.GetDatabaseTestFramework(true);

            // assert
            IEnumerable<string> tableNames = databaseTestFramework.GenericDatabaseInteractor().GetAllTableNames();
            Assert.IsTrue(tableNames.Any(tableName => tableName.Contains("Customers")), $"The table \"Customers\" does not exist. Existing tables: {string.Join(", ", tableNames)}");
        }

        public abstract void MigrationsAreAppliedOnlyOnceTest();

        /// <summary>Runs the migrations a second time and checks that this does not fail, because the application applies them on every start.</summary>
        protected void MigrationsAreAppliedOnlyOnce()
        {
            // arrange
            DatabaseTestFrameworkTemplate databaseTestFramework = this.GetDatabaseTestFramework(true);
            IGenericDatabaseInteractor databaseInteractor = databaseTestFramework.GenericDatabaseInteractor();
            IDotNetWebAPICodeUnitDatabaseInteractor interactor = databaseInteractor.Accept(new GetDatabaseInteractorVisitor());

            // act
            databaseInteractor.DoAllMigrations(interactor.GetAllMigrations(), new TimeService());

            // assert
            Assert.IsTrue(databaseInteractor.GetAllTableNames().Any(tableName => tableName.Contains("Customers")));
        }
    }
}

using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Database;
using System;

namespace DotNetWebAPICodeUnit.Core.Miscellaneous
{
    /// <summary>Maps a generic database-interactor of the library to the codeunit-specific one. A database-type which this codeunit does not support is rejected here instead of failing later with a wrong sql-dialect.</summary>
    public class GetDatabaseInteractorVisitor : IGenericDatabaseInteractorVisitor<IDotNetWebAPICodeUnitDatabaseInteractor>
    {
        /// <inheritdoc />
        public IDotNetWebAPICodeUnitDatabaseInteractor Handle(MariaDBDatabaseInteractor mariaDBDatabaseInteractor)
        {
            return new DatabaseInteractorMariaDB(mariaDBDatabaseInteractor);
        }

        /// <inheritdoc />
        public IDotNetWebAPICodeUnitDatabaseInteractor Handle(PostgreSQLDatabaseInteractor postgreSQLDatabaseInteractor)
        {
            return new DatabaseInteractorPostgreSQL(postgreSQLDatabaseInteractor);
        }

        /// <inheritdoc />
        public IDotNetWebAPICodeUnitDatabaseInteractor Handle(OracleDatabaseInteractor oracleDatabaseInteractor)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        public IDotNetWebAPICodeUnitDatabaseInteractor Handle(SQLServerDatabaseInteractor sQLServerDatabaseInteractor)
        {
            throw new NotSupportedException();
        }
    }
}

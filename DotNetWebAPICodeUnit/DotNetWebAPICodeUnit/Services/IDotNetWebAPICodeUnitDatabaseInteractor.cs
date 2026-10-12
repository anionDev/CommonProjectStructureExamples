using GRYLibrary.Core.APIServer.Services.Database;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Adds the codeunit-specific parts to the generic database-interactor of the library: the migrations and the sql-statements of this codeunit.</summary>
    public interface IDotNetWebAPICodeUnitDatabaseInteractor : IProjectSpecificDatabaseInteractor
    {
        public ISQLProvider GetSQLProvider();
    }
}

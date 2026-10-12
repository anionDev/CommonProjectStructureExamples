using DotNetWebAPICodeUnit.Core.Miscellaneous;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Sql-provider which uses the statements written for PostgreSQL.</summary>
    public class SQLProviderPostgreSQL : SQLProvider
    {
        public SQLProviderPostgreSQL() : base("PostgreSQL") { }
    }
}

using DotNetWebAPICodeUnit.Core.Miscellaneous;

namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Sql-provider which uses the statements written for MariaDB.</summary>
    public class SQLProviderMariaDB : SQLProvider
    {
        public SQLProviderMariaDB() : base("MariaDB") { }
    }
}

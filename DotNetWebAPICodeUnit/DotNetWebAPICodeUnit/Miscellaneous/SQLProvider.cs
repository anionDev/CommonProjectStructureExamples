using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.Misc;

namespace DotNetWebAPICodeUnit.Core.Miscellaneous
{
    /// <summary>Loads the sql-statements from the embedded resources of this codeunit. The statements themselves are sql-files and not strings in the sourcecode, so they stay readable and can get tested against the database directly.</summary>
    public abstract class SQLProvider : AbstractSQLProvider, ISQLProvider
    {
        /// <summary>Initializes the sql-provider for the given database-type.</summary>
        /// <param name="databaseType">The database-type which selects the folder of the embedded sql-scripts (for example "MariaDB" or "PostgreSQL").</param>
        protected SQLProvider(string databaseType) : base($"DotNetWebAPICodeUnit.Core.Resources.Database.{databaseType}.Statements") { }

        /// <inheritdoc />
        public string GetScriptCreateCustomer()
        {
            return this.LoadSQLScript("CreateCustomer");
        }

        /// <inheritdoc />
        public string GetScriptUpdateCustomer()
        {
            return this.LoadSQLScript("UpdateCustomer");
        }

        /// <inheritdoc />
        public string GetScriptRemoveCustomer()
        {
            return this.LoadSQLScript("RemoveCustomer");
        }

        /// <inheritdoc />
        public string GetScriptGetCustomer()
        {
            return this.LoadSQLScript("GetCustomer");
        }

        /// <inheritdoc />
        public string GetScriptGetAllCustomers()
        {
            return this.LoadSQLScript("GetAllCustomers");
        }

        /// <inheritdoc />
        public string GetScriptResetDatabase()
        {
            return this.LoadSQLScript("ResetDatabase");
        }
    }
}

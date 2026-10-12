using DotNetWebAPICodeUnit.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.SQLProviderTests
{
    /// <summary>
    /// Testcases which every sql-provider must fulfill: every getter must return exactly the content of the
    /// embedded sql-file it is supposed to load. This is checked without a database, because the sql-provider
    /// only loads text and does not execute it; the only thing which can go wrong here is a wrong folder-name
    /// or a wrong file-name. The classes which inherit from this one only add which database-type is tested.
    /// </summary>
    public abstract class SQLProviderTestsBase
    {
        protected abstract ISQLProvider GetSQLProvider();

        /// <summary>The name of the database-type-folder under "Resources/Database", so "MariaDB" or "PostgreSQL".</summary>
        protected abstract string GetDatabaseTypeFolderName();

        /// <summary>Reads the sql-file which the sql-provider is expected to load, directly from the sourcecode instead of through the sql-provider itself.</summary>
        private string GetExpectedScriptContent(string scriptName)
        {
            string file = Path.Combine(DotNetWebAPICodeUnit.Tests.TestUtilities.Constants.GeneralConstants.CodeUnitFolder, "DotNetWebAPICodeUnit", "Resources", "Database", this.GetDatabaseTypeFolderName(), "Statements", $"{scriptName}.sql");
            return File.ReadAllText(file, new UTF8Encoding(false));
        }

        public abstract void GetScriptCreateCustomerTest();

        protected void GetScriptCreateCustomer()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptCreateCustomer();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("CreateCustomer"), actualScript);
        }

        public abstract void GetScriptUpdateCustomerTest();

        protected void GetScriptUpdateCustomer()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptUpdateCustomer();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("UpdateCustomer"), actualScript);
        }

        public abstract void GetScriptRemoveCustomerTest();

        protected void GetScriptRemoveCustomer()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptRemoveCustomer();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("RemoveCustomer"), actualScript);
        }

        public abstract void GetScriptGetCustomerTest();

        protected void GetScriptGetCustomer()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptGetCustomer();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("GetCustomer"), actualScript);
        }

        public abstract void GetScriptGetAllCustomersTest();

        protected void GetScriptGetAllCustomers()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptGetAllCustomers();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("GetAllCustomers"), actualScript);
        }

        public abstract void GetScriptResetDatabaseTest();

        protected void GetScriptResetDatabase()
        {
            // arrange
            ISQLProvider sqlProvider = this.GetSQLProvider();

            // act
            string actualScript = sqlProvider.GetScriptResetDatabase();

            // assert
            Assert.AreEqual(this.GetExpectedScriptContent("ResetDatabase"), actualScript);
        }
    }
}

using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.Misc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetWebAPICodeUnit.Tests.Testcases.Services.SQLProviderTests
{
    /// <summary>Runs the testcases of the sql-provider against the scripts written for PostgreSQL.</summary>
    [TestClass]
    public class SQLProviderTestsForPostgreSQL : SQLProviderTestsBase
    {
        protected override ISQLProvider GetSQLProvider()
        {
            return new SQLProviderPostgreSQL();
        }

        protected override string GetDatabaseTypeFolderName()
        {
            return "PostgreSQL";
        }

        [TestMethod(DisplayName = nameof(GetScriptCreateCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptCreateCustomerTest()
        {
            this.GetScriptCreateCustomer();
        }

        [TestMethod(DisplayName = nameof(GetScriptUpdateCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptUpdateCustomerTest()
        {
            this.GetScriptUpdateCustomer();
        }

        [TestMethod(DisplayName = nameof(GetScriptRemoveCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptRemoveCustomerTest()
        {
            this.GetScriptRemoveCustomer();
        }

        [TestMethod(DisplayName = nameof(GetScriptGetCustomerTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptGetCustomerTest()
        {
            this.GetScriptGetCustomer();
        }

        [TestMethod(DisplayName = nameof(GetScriptGetAllCustomersTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptGetAllCustomersTest()
        {
            this.GetScriptGetAllCustomers();
        }

        [TestMethod(DisplayName = nameof(GetScriptResetDatabaseTest))]
        [TestProperty(nameof(GRYLibrary.Core.Misc.TestKind), nameof(GRYLibrary.Core.Misc.TestKind.UnitTest))]
        public override void GetScriptResetDatabaseTest()
        {
            this.GetScriptResetDatabase();
        }
    }
}

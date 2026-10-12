namespace DotNetWebAPICodeUnit.Core.Services
{
    /// <summary>Provides the sql-statements of this codeunit. There is one implementation per supported database-type, because the dialects differ.</summary>
    public interface ISQLProvider
    {
        string GetScriptCreateCustomer();
        string GetScriptUpdateCustomer();
        string GetScriptRemoveCustomer();
        string GetScriptGetCustomer();
        string GetScriptGetAllCustomers();
        string GetScriptResetDatabase();
    }
}

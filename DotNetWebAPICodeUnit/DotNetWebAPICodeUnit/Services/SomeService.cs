namespace DotNetWebAPICodeUnit.Core.Services
{
    public class SomeService : ISomeService
    {
        public decimal Add(decimal parameter1, decimal parameter2)
        {
            return DotNetLibraryCodeUnit.Core.Utilities.Add(parameter1, parameter2);
        }
    }
}

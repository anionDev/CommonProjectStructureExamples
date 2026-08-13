using GRYLibrary.Core.APIClient;
using GRYLibrary.Core.Misc;
using GUtilities = GRYLibrary.Core.Misc.Utilities;

namespace DotNetWebAPIClientCodeUnit.Core
{
    public sealed class DotNetWebAPIClient : IDotNetWebAPIClient
    {
        private readonly GenericAPIClient _GenericAPIClient;
        public DotNetWebAPIClient(IGenericAPIClientConfiguration genericAPIClientConfiguration)
        {
            this._GenericAPIClient = new GenericAPIClient(genericAPIClientConfiguration);
        }

        public decimal Add(decimal parameter1, decimal parameter2)
        {
            string route = $"API/V1/ExampleController/Calculator/Add/?parameter1={GUtilities.DecimalToString(parameter1)}&parameter2={GUtilities.DecimalToString(parameter2)}";
            return this._GenericAPIClient.GetAsDecimalAsync(route).WaitAndGetResult();
        }

        public void Dispose()
        {
            _GenericAPIClient.Dispose();
        }
    }
}

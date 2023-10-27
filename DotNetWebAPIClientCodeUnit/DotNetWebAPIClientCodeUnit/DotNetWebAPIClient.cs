using GRYLibrary.Core.GenericAPIClient;
using GRYLibrary.Core.Miscellaneous;
using System;
using System.Web;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;

namespace CCOT.DataCollectorClient.Core
{
    public sealed class DotNetWebAPIClient : IDotNetWebAPIClient
    {
        private readonly GenericAPIClient _GenericAPIClient;
        public DotNetWebAPIClient(IGenericAPIClientConfiguration genericAPIClientConfiguration)
        {
            this._GenericAPIClient = new GenericAPIClient(genericAPIClientConfiguration);
        }

        public void Dispose()
        {
        }
        public decimal Add(decimal input1, decimal input2)
        {
            string route = $"API/ExampleController/{nameof(Add)}/{GUtilities.DecimalToString(input1)}/{GUtilities.DecimalToString(input2)}";
            return this._GenericAPIClient.GetAsDecimalAsync(route).WaitAndGetResult();
        }
    }
}

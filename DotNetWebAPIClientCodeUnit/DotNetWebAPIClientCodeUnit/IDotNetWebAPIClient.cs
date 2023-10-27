using System;

namespace CCOT.DataCollectorClient.Core
{
    public interface IDotNetWebAPIClient : IDisposable
    {
        public decimal Add(decimal input1, decimal input2);
    }
}

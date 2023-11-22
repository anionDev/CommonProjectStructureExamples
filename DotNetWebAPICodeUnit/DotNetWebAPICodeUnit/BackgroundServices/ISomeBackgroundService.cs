using GRYLibrary.Core.APIServer.BaseServices;
using GRYLibrary.Core.Miscellaneous;
using System.Diagnostics.Metrics;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public interface ISomeBackgroundService: IIteratingBackgroundService
    {
        public Counter<decimal> SomeMetricsValue { get; }
        void CalculateSomeMetricsValus();
    }
}

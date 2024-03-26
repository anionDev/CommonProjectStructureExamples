using GRYLibrary.Core.APIServer.BaseServices;
using System.Diagnostics.Metrics;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public interface ISomeBackgroundService: IIteratingBackgroundService
    {
        public Counter<decimal> SomeMetricsValue1 { get; }
        void CalculateSomeMetricsValus();
    }
}

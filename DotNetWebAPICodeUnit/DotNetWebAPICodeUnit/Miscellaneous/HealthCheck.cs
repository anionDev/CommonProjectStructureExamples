using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetWebAPICodeUnit.Core.Miscellaneous
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IGeneralLogger _GeneralLogger;
        public HealthCheck(IGeneralLogger logger)
        {
            _GeneralLogger = logger;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            string message = $"Service {GeneralConstants.CodeUnitName} is healthy.";
            _GeneralLogger.Log(message, Microsoft.Extensions.Logging.LogLevel.Warning);
            return Task.FromResult(HealthCheckResult.Healthy(message));
        }
    }
}

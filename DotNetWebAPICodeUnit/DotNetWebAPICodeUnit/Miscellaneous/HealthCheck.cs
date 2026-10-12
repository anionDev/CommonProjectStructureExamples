using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.Services.Init;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GUtilities = GRYLibrary.Core.Misc.Utilities;

namespace DotNetWebAPICodeUnit.Core.Miscellaneous
{
    public class HealthCheck : IHealthCheck
    {
        private readonly IGeneralLogger _Logger;
        private readonly IPersistence _Persistence;
        private readonly IInitializationService _InitializationService;
        public HealthCheck(IGeneralLogger logger, IPersistence persistence, IInitializationService initializationService)
        {
            this._Logger = logger;
            this._Persistence = persistence;
            this._InitializationService = initializationService;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Tools.CheckHealthAsync(this._Logger, () =>
            {
                IList<string> messages = new List<string>();
                HealthStatus result = HealthStatus.Healthy;
                if (GUtilities.CheckCancellationToken(messages, cancellationToken, out (HealthStatus, IList<string>) abortResult))
                { return abortResult; }
                Tools.CheckSingleExternalService(this._Logger, this._Persistence.GetType().Name, this._Persistence, ref result, messages, true, true);
                return (result, messages);
            }, context, cancellationToken, this._InitializationService);
        }
    }
}

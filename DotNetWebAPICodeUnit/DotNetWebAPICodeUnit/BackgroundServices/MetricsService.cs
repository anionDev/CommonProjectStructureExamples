using GRYLibrary.Core.APIServer.BaseServices;
using GRYLibrary.Core.APIServer.Services.Logger;
using GRYLibrary.Core.APIServer.Settings;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using GRYLibrary.Core.Logging.GRYLogger;
using Microsoft.Extensions.Logging;
using Prometheus;
using System;
using DotNetWebAPICodeUnit.Core.Constants;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public class MetricsService : IteratingBackgroundService, IMetricsService
    {

        public Gauge MetricRandomGauge { get; private set; }
        private readonly Random _Random = new Random();
        // The logger is taken as "IServerLog" and not as "IGRYLog", because that is what the dependency-injection
        // of the library provides. Asking for "IGRYLog" directly makes the creation of this service fail.
        public MetricsService(IApplicationConstants<CodeUnitSpecificConstants> constants, IServerLog log) : base(constants.ExecutionMode, log.Logger)
        {
            this.Enabled = true;
            this.AdditionalDelay = TimeSpan.FromSeconds(5);
            this.MetricRandomGauge = Metrics.CreateGauge(CodeUnitSpecificConstants.MetricsNameRandomGauge, "Some random gauge-metrics");
        }

        public void CalculateMetrics()
        {
            try
            {
                this._Logger.Log("Calculate metrics", LogLevel.Debug);
                this.MetricRandomGauge.Set(_Random.NextDouble());
            }
            catch (Exception exception)
            {
                this._Logger.Log("Error while calculating metrics", exception);
            }
        }

        protected override void Run()
        {
            this.CalculateMetrics();
        }
    }
}

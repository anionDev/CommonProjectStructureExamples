using GRYLibrary.Core.APIServer.BaseServices;
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
        public MetricsService(IApplicationConstants<CodeUnitSpecificConstants> constants, IGRYLog logger) : base(constants.ExecutionMode, logger)
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
                this._Logger.LogException(exception, "Error while calculating metrics");
            }
        }

        protected override void Run()
        {
            this.CalculateMetrics();
        }
    }
}

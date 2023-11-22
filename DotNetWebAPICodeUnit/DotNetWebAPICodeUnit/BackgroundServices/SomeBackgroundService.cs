using DotNetWebAPICodeUnit.Core.Configuration;
using GRYLibrary.Core.APIServer.Settings;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using GRYLibrary.Core.APIServer.BaseServices;
using GRYLibrary.Core.Miscellaneous;
using System.Diagnostics.Metrics;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public class SomeBackgroundService : IteratingBackgroundService, ISomeBackgroundService
    {
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; private set; }
        private readonly Meter _SomeMeter;
        public Counter<decimal> SomeMetricsValue { get; private set; }
        public SomeBackgroundService(ISomeBackgroundServiceSettings someBackgroundServiceSettings, IApplicationConstants applicationConstants) : base(applicationConstants.ExecutionMode, GeneralLoggerExtensions.SetupLogger(someBackgroundServiceSettings.LogConfiguration, applicationConstants.GetLogFolder(), nameof(SomeBackgroundService)))
        {
            this.SomeBackgroundServiceSettings = someBackgroundServiceSettings;
            this.Enabled = this.SomeBackgroundServiceSettings.Enabled;
            _SomeMeter = new Meter("MyCompany.MyProduct.MyLibrary.MetricsName");//https://learn.microsoft.com/en-us/dotnet/core/diagnostics/metrics-instrumentation
            SomeMetricsValue = _SomeMeter.CreateCounter<decimal>("hatco.store.hats_sold");
        }

        protected override void Run()
        {
            Thread.Sleep(TimeSpan.FromSeconds(20));
            this._Logger.Log("Do some scheduled job...", LogLevel.Debug);
            CalculateSomeMetricsValus();
        }

        public void CalculateSomeMetricsValus()
        {
            SomeMetricsValue.Add(PercentValue.Random().Value);
        }

        public override void Dispose()
        {
            _SomeMeter.Dispose();
        }
    }
}

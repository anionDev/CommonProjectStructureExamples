using DotNetWebAPICodeUnit.Core.Configuration;
using GRYLibrary.Core.APIServer.Settings;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using System.Threading.Tasks;
using GRYLibrary.Core.APIServer.Utilities;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public class SomeBackgroundService : IteratingBackgroundService, ISomeBackgroundService
    {
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; private set; }
        public SomeBackgroundService(ISomeBackgroundServiceSettings someBackgroundServiceSettings, IApplicationConstants applicationConstants) : base(applicationConstants.ExecutionMode)
        {
            this.SomeBackgroundServiceSettings = someBackgroundServiceSettings;
            this.Enabled = this.SomeBackgroundServiceSettings.Enabled;
            this.Logger = GeneralLoggerExtensions.SetupLogger(someBackgroundServiceSettings.LogConfiguration, applicationConstants.GetLogFolder(), this.GetType().Name);
        }

        protected override void Run()
        {
            Thread.Sleep(TimeSpan.FromSeconds(20));
            this.Logger.Log("Do some scheduled job...", LogLevel.Debug);
        }
    }
}

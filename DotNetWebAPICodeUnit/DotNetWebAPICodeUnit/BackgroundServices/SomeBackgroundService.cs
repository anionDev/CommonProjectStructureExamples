using DotNetWebAPICodeUnit.Core.Configuration;
using GRYLibrary.Core.APIServer.Settings;
using GRYLibrary.Core.GeneralPurposeLogger;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;

namespace DotNetWebAPICodeUnit.Core.BackgroundServices
{
    public class SomeBackgroundService : ISomeBackgroundService
    {
        public IGeneralLogger Logger { get; private set; }
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; private set; }
        public bool Running { get; private set; }
        public bool Enabled { get; private set; }
        public SomeBackgroundService(ISomeBackgroundServiceSettings someBackgroundServiceSettings, IApplicationConstants applicationConstants)
        {
            this.SomeBackgroundServiceSettings = someBackgroundServiceSettings;
            this.Logger = GeneralLoggerExtensions.SetupLogger(someBackgroundServiceSettings.LogConfiguration, applicationConstants.GetLogFolder(), this.GetType().Name);
        }

        public void JobImplementation()
        {
            // do some scheduled job
        }

        public void StartAsyncImplementation()
        {
            this.Logger.Log(this.GetType().FullName, LogLevel.Information, true, true, () =>
            {
                this.Running = true;
                while (this.Enabled)
                {
                    this.Logger.Log($"{this.GetType().FullName}.{nameof(JobImplementation)}", LogLevel.Information, false, true, () => this.JobImplementation());
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
                this.Running = false;
            });
        }

        public void StopImplementation()
        {
            this.Enabled = false;
            GUtilities.WaitUntilConditionIsTrue(() => !this.Running);
        }
    }
}

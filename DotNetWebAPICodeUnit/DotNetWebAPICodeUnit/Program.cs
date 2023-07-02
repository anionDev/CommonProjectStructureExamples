using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.GenericWebAPIServer.ConcreteEnvironments;
using GRYLibrary.Core.GenericWebAPIServer.ExecutionModes;
using GRYLibrary.Core.Miscellaneous;
using GRYLibrary.Core.Miscellaneous.ConsoleApplication;
using Microsoft.Extensions.DependencyInjection;
using GRYLibrary.Core.GenericWebAPIServer.Settings;
using GRYLibrary.Core.GenericWebAPIServer.Settings.CommonRoutes;
using GRYLibrary.Core.GenericWebAPIServer;
using DotNetWebAPICodeUnit.Core.Configuration;
using DotNetWebAPICodeUnit.Core.Services;
using DotNetWebAPICodeUnit.Core.BackgroundServices;
using GRYLibrary.Core.GenericWebAPIServer.Middlewares.ConcreteMiddlewares;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            ExecutionMode executionMode = Utilities.GetExecutionMode();
            GRYConsoleApplication<CommandlineParameter, APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>> consoleApplication = new GRYConsoleApplication<CommandlineParameter, APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>>(APIServer<CodeUnitSpecificConstants, CodeUnitSettings, CommandlineParameter>.WebAPIMain, GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitVersion.ToString(), CodeUnitSpecificConstants.AppDescription, true, executionMode);
            APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings> apiServerInitializer = new APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>(GeneralConstants.CodeUnitName, Version3.Parse(GeneralConstants.CodeUnitVersion), executionMode, GetEnvironmentTargetType(), new CodeUnitSpecificConstants(), GeneralConstants.Domain, CodeUnitSpecificConstants.AppDescription, new CodeUnitSettings(), GeneralConstants.NonProductiveCertificatePasswordHex, GeneralConstants.NonProductiveCertificatePFXHex);
            #region DotNetWebAPICodeUnit-related settings
            apiServerInitializer.ApplicationConstants.CommonRoutes = new HostCommonRoutes();
            apiServerInitializer.ApplicationConstants.RequestLoggingMiddleware = typeof(RequestLoggingMiddleware);
            apiServerInitializer.InitialApplicationConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation = new HostCommonRoutes()
            {
                ContactLink = $"https://information.{GeneralConstants.Domain}/Contact",
                LicenseLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/License",
                TermsOfServiceLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/TermsOfService"
            };
            apiServerInitializer.ConfigureServices = (services, constants, persistedConfiguration) =>
            {
                services.AddSingleton<ISomeService, SomeService>();

                ServiceProvider serviceProvider = services.BuildServiceProvider();
                ISomeBackgroundService someBackgroundService = serviceProvider.GetService<ISomeBackgroundService>();

                apiServerInitializer.PreRun = (constants, persistedConfiguration) =>
                {
                    someBackgroundService.StartAsync();
                };
                apiServerInitializer.PostRun = (constants, persistedConfiguration) =>
                {
                    someBackgroundService.Stop();
                };
            };
            #endregion
            return consoleApplication.Main(commandlineArguments, apiServerInitializer);
        }

        private static GRYEnvironment GetEnvironmentTargetType()
        {
#if Development
            return Development.Instance;
#elif QualityCheck
            return QualityCheck.Instance;
#elif Productive
            return Productive.Instance;
#else
            throw new System.Collections.Generic.KeyNotFoundException("Unknown environmenttargettype.");
#endif
        }
    }
}

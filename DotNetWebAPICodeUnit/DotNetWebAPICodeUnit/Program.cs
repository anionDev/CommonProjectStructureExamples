using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.GenericWebAPIServer.ConcreteEnvironments;
using GRYLibrary.Core.GenericWebAPIServer.ExecutionModes;
using GRYLibrary.Core.Miscellaneous;
using GRYLibrary.Core.Miscellaneous.ConsoleApplication;
using Microsoft.Extensions.DependencyInjection;
using GRYLibrary.Core.GenericWebAPIServer.Settings;
using GRYLibrary.Core.GenericWebAPIServer;
using DotNetWebAPICodeUnit.Core.Configuration;
using DotNetWebAPICodeUnit.Core.Services;
using DotNetWebAPICodeUnit.Core.BackgroundServices;
using GRYLibrary.Core.GenericWebAPIServer.CommonRoutes;
using GRYLibrary.Core.GenericWebAPIServer.DefinedMiddlewares.RequestLogger;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            ExecutionMode executionMode = Utilities.GetExecutionMode();
            GRYConsoleApplication<CommandlineParameter, APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>> consoleApplication = new GRYConsoleApplication<CommandlineParameter, APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>>(WebAPIServer<CodeUnitSpecificConstants, CodeUnitSettings, CommandlineParameter>.WebAPIMain, GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitVersion.ToString(), CodeUnitSpecificConstants.AppDescription, true, executionMode);
            APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings> apiServerInitializer = new APIServerInitializer<CodeUnitSpecificConstants, CodeUnitSettings>(GeneralConstants.CodeUnitName, Version3.Parse(GeneralConstants.CodeUnitVersion), executionMode, GetEnvironmentTargetType(), new CodeUnitSpecificConstants(), GeneralConstants.Domain, CodeUnitSpecificConstants.AppDescription, new CodeUnitSettings(), GeneralConstants.DevelopmentCertificatePasswordHex, GeneralConstants.DevelopmentCertificatePFXHex);
         
            #region DotNetWebAPICodeUnit-related settings
            apiServerInitializer.ApplicationConstants.CommonRoutes = new HostCommonRoutes();
            apiServerInitializer.ApplicationConstants.RequestLoggingMiddleware = typeof(RequestLoggingMiddleware);
            apiServerInitializer.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeBool = true;
            apiServerInitializer.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeInt = 42;
            apiServerInitializer.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeString = "some string value";
            apiServerInitializer.InitialApplicationConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation = new CommonRoutesInformation()
            {
                ContactLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/Contact",
                LicenseLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/License",
                TermsOfServiceLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/TermsOfService"
            };
            apiServerInitializer.ConfigureServices = (services, constants, persistedConfiguration) =>
            {
                services.AddSingleton<ISomeService, SomeService>();
                services.AddSingleton<ISomeBackgroundService, SomeBackgroundService>();
                services.AddSingleton<ICommonRoutesInformation>(persistedConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation);

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

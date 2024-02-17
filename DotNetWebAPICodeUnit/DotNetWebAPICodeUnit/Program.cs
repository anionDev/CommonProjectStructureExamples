using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.Extensions.DependencyInjection;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;
using DotNetWebAPICodeUnit.Core.Configuration;
using DotNetWebAPICodeUnit.Core.Services;
using DotNetWebAPICodeUnit.Core.BackgroundServices;
using GRYLibrary.Core.APIServer.CommonRoutes;
using GRYLibrary.Core.APIServer.ConcreteEnvironments;
using GRYLibrary.Core.Miscellaneous.FilePath;
using GRYLibrary.Core.APIServer.ExecutionModes;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GRYLogger;
using DotNetWebAPICodeUnit.Core.Miscellaneous;
using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using GRYLibrary.Core.APIServer.MidT.RLog;
using GRYLibrary.Core.APIServer.Mid.DLog;
using GRYLibrary.Core.APIServer.MaintenanceRoutes;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            return Tools.RunAPIServer<CodeUnitSpecificCommandlineParameter, CodeUnitSpecificConstants, CodeUnitSpecificConfiguration>(GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitDescription, Version3.Parse(GeneralConstants.CodeUnitVersion), GetEnvironmentTargetType(), GUtilities.GetExecutionMode(commandlineArguments), commandlineArguments, (apiServerConfiguration) =>
            {
                apiServerConfiguration.SetInitialzationInformationAction = (initializationInformation) => //HINT initialization for first run (used when configuration-file not exists)
                {
                    string domain = Tools.GetDefaultDomainValue(GeneralConstants.CodeUnitName);
                    initializationInformation.ApplicationConstants.CommonRoutesHostInformation = new HostCommonRoutes();
                    initializationInformation.ApplicationConstants.HostMaintenanceInformation = new HostMaintenanceRoutes();
                    initializationInformation.ApplicationConstants.LoggingMiddleware = typeof(DRequestLoggingMiddleware);
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation = new CommonRoutesInformation()
                    {
                        ContactLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/Contact",
                        LicenseLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/License",
                        TermsOfServiceLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/TermsOfService"
                    };
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.MaintenanceRoutesInformation = new MaintenanceRoutesInformation();
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Domain = domain;
                    bool runServices = initializationInformation.ApplicationConstants.ExecutionMode is RunProgram;
                    bool verbose = initializationInformation.ApplicationConstants.Environment is not Productive;
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomeBackgroundServiceSettings = new SomeBackgroundServiceSettings()
                    {
                        Enabled = runServices,
                        LogConfiguration = GRYLogConfiguration.GetCommonConfiguration(AbstractFilePath.FromString($"./{nameof(SomeBackgroundService)}.log"), verbose),
                        SomePropertyOfTypeBool = true,
                        SomePropertyOfTypeInt = 42,
                        SomePropertyOfTypeString = "some string value",
                    };
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.ConfigurationForDLoggingMiddleware = new DRequestLoggingConfiguration();
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.HostAPISpecificationForInNonDevelopmentEnvironment = true;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Protocol = initializationInformation.ApplicationConstants.ExecutionMode.Accept(new GetProcolVisitor(domain));
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Domain = domain;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePasswordHex = GeneralConstants.DevelopmentCertificatePasswordHex;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePFXHex = GeneralConstants.DevelopmentCertificatePFXHex;
                };
                apiServerConfiguration.SetFunctionalInformationAction = (functionalInformation) => //initialization for every run
                {
                    functionalInformation.WebApplicationBuilder.Services.AddHealthChecks().AddCheck<HealthCheck>(nameof(HealthCheck));
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<ISomeService, SomeService>();
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<ISomeBackgroundService, SomeBackgroundService>();
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<ISomeBackgroundServiceSettings>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.SomeBackgroundServiceSettings);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<ICommonRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IMaintenanceRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.MaintenanceRoutesInformation);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IRequestLoggingConfiguration>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.ConfigurationForLoggingMiddleware);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IDRequestLoggingConfiguration>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.ConfigurationForDLoggingMiddleware);
                    ServiceProvider serviceProvider = functionalInformation.WebApplicationBuilder.Services.BuildServiceProvider();

                    functionalInformation.WebApplicationBuilder.Services.AddOpenTelemetry();

                    ISomeBackgroundService someBackgroundService = serviceProvider.GetService<ISomeBackgroundService>();

                    functionalInformation.PreRun = (webApplication) =>
                    {
                        someBackgroundService.StartAsync();
                    };
                    functionalInformation.PostRun = (webApplication) =>
                    {
                        someBackgroundService.Stop().Wait();
                    };
                };
                apiServerConfiguration.ConfigureWebApplication = (functionalInformationForWebApplication) =>
                {
                    functionalInformationForWebApplication.WebApplication.MapHealthChecks(GRYLibrary.Core.APIServer.Utilities.Constants.UsualHealthCheckEndpoint);
                    functionalInformationForWebApplication.WebApplication.UseOpenTelemetryPrometheusScrapingEndpoint(GRYLibrary.Core.APIServer.Utilities.Constants.UsualMetricsEndpoint);
                };
            });
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

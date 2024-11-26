using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.Misc;
using Microsoft.Extensions.DependencyInjection;
using GUtilities = GRYLibrary.Core.Misc.Utilities;
using DNWAPICUUtilities = DotNetWebAPICodeUnit.Core.Miscellaneous.Utilities;
using DotNetWebAPICodeUnit.Core.Configuration;
using DotNetWebAPICodeUnit.Core.Services;
using GRYLibrary.Core.APIServer.CommonRoutes;
using GRYLibrary.Core.APIServer.ConcreteEnvironments;
using GRYLibrary.Core.APIServer.ExecutionModes;
using GRYLibrary.Core.APIServer.Utilities;
using DotNetWebAPICodeUnit.Core.Miscellaneous;
using GRYLibrary.Core.APIServer.MidT.RLog;
using GRYLibrary.Core.APIServer.MaintenanceRoutes;
using GRYLibrary.Core.Logging.GeneralPurposeLogger;
using Microsoft.EntityFrameworkCore;
using DotNetWebAPICodeUnit.Core.Database.Contexts;
using GRYLibrary.Core.APIServer.Mid.M05DLog;
using DotNetWebAPICodeUnit.Core.BackgroundServices;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            return Tools.RunAPIServer<CodeUnitSpecificCommandlineParameter, CodeUnitSpecificConstants, CodeUnitSpecificConfiguration>(GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitDescription, Version3.Parse(GeneralConstants.CodeUnitVersion), DNWAPICUUtilities.GetEnvironmentTargetType(), GUtilities.GetExecutionMode(commandlineArguments), commandlineArguments, (apiServerConfiguration) =>
            {
                apiServerConfiguration.SetInitialzationInformationAction = (initializationInformation) => //HINT initialization for first run (used when configuration-file not exists)
                {
                    string domain = Tools.GetDefaultDomainValue(GeneralConstants.CodeUnitName);
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.SetDomainAndPublichUrlToDefault(domain);
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
                    bool runServices = initializationInformation.ApplicationConstants.ExecutionMode is RunProgram;
                    bool verbose = initializationInformation.ApplicationConstants.Environment is not Productive;
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.ConfigurationForDLoggingMiddleware = new DRequestLoggingConfiguration();
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.HostAPISpecificationForInNonDevelopmentEnvironment = true;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Protocol = initializationInformation.ApplicationConstants.ExecutionMode.Accept(new GetProcolVisitor(domain));
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Domain = domain;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePasswordHex = GeneralConstants.DevelopmentCertificatePasswordHex;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePFXHex = GeneralConstants.DevelopmentCertificatePFXHex;
                };
                apiServerConfiguration.SetFunctionalInformationAction = (functionalInformation) => //initialization for every run
                {
                    IGeneralLogger logger = functionalInformation.Logger;
                    bool runPersistent = functionalInformation.InitializationInformation.ApplicationConstants.Environment is not Development && functionalInformation.InitializationInformation.ApplicationConstants.ExecutionMode is RunProgram;
                    if (runPersistent)
                    {
                        functionalInformation.WebApplicationBuilder.Services.AddDbContext<DatabaseContext>(options =>
                        {
                            string connectionString = functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.DatabaseConnectionString;
                            Tools.ConnectToDatabase(() => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), logger, GUtilities.AdaptMariaDBSQLConnectionString(connectionString, true));
                        }, ServiceLifetime.Transient);
                        functionalInformation.WebApplicationBuilder.Services.AddSingleton<IPersistence, DatabasePersistence>();
                    }
                    else
                    {
                        functionalInformation.WebApplicationBuilder.Services.AddSingleton<IPersistence, TransientPersistence>();
                    }
                    functionalInformation.WebApplicationBuilder.Services.AddHealthChecks().AddCheck<HealthCheck>(nameof(HealthCheck));
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IMathService, MathService>();
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<ICommonRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IMaintenanceRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.MaintenanceRoutesInformation);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IRequestLoggingConfiguration>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.ConfigurationForLoggingMiddleware);
                    functionalInformation.WebApplicationBuilder.Services.AddSingleton<IDRequestLoggingConfiguration>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.ConfigurationForDLoggingMiddleware);
                };
                apiServerConfiguration.ConfigureWebApplication = (functionalInformationForWebApplication) =>
                {
                    IMetricsService metricsService = functionalInformationForWebApplication.WebApplication.Services.GetService<IMetricsService>();
                    functionalInformationForWebApplication.PreRun = () =>
                    {
                        metricsService.StartAsync();
                    };
                    functionalInformationForWebApplication.PostRun = () =>
                    {
                        metricsService.Stop().Wait();
                    };
                };
            });
        }
    }
}

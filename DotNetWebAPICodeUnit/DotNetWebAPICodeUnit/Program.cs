using DotNetWebAPICodeUnit.Core.Constants;
using GRYLibrary.Core.Miscellaneous;
using Microsoft.Extensions.DependencyInjection;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;
using DotNetWebAPICodeUnit.Core.Configuration;
using DotNetWebAPICodeUnit.Core.Services;
using DotNetWebAPICodeUnit.Core.BackgroundServices;
using GRYLibrary.Core.APIServer.CommonRoutes;
using GRYLibrary.Core.APIServer.Mid.RequestLogger;
using GRYLibrary.Core.APIServer.ConcreteEnvironments;
using GRYLibrary.Core.Miscellaneous.FilePath;
using GRYLibrary.Core.APIServer.ExecutionModes;
using GRYLibrary.Core.APIServer.Utilities;
using GRYLibrary.Core.Logging.GRYLogger;
using GRYLibrary.Core.APIServer.Mid.Logging;

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
                    initializationInformation.ApplicationConstants.CommonRoutes = new HostCommonRoutes();
                    initializationInformation.ApplicationConstants.RequestLoggingMiddleware = typeof(RequestLoggingMiddleware);
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation = new CommonRoutesInformation()
                    {
                        ContactLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/Contact",
                        LicenseLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/License",
                        TermsOfServiceLink = $"https://information.{domain}/Products/{GeneralConstants.CodeUnitName}/TermsOfService"
                    };
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
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.ConfigurationForRequestLoggingMiddleware = new RequestLoggingConfiguration();
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.HostAPISpecificationForInNonDevelopmentEnvironment = true;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Protocol = initializationInformation.ApplicationConstants.ExecutionMode.Accept(new GetProcolVisitor(domain));
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Domain = domain;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePasswordHex = GeneralConstants.DevelopmentCertificatePasswordHex;
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.DevelopmentCertificatePFXHex = GeneralConstants.DevelopmentCertificatePFXHex;
                };
                apiServerConfiguration.SetFunctionalInformationAction = (functionalInformation) => //initialization for every run
                {
                    functionalInformation.ServiceCollection.AddSingleton<ISomeService, SomeService>();
                    functionalInformation.ServiceCollection.AddSingleton<ISomeBackgroundService, SomeBackgroundService>();
                    functionalInformation.ServiceCollection.AddSingleton<ISomeBackgroundServiceSettings>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.SomeBackgroundServiceSettings);
                    functionalInformation.ServiceCollection.AddSingleton<ICommonRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation);
                    functionalInformation.ServiceCollection.AddSingleton<IRequestLoggingConfiguration>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.ConfigurationForRequestLoggingMiddleware);
                    ServiceProvider serviceProvider = functionalInformation.ServiceCollection.BuildServiceProvider();
                    ISomeBackgroundService someBackgroundService = serviceProvider.GetService<ISomeBackgroundService>();
                    functionalInformation.PreRun = () =>
                    {
                        someBackgroundService.StartAsync();
                    };
                    functionalInformation.PostRun = () =>
                    {
                        someBackgroundService.Stop().Wait();
                    };
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

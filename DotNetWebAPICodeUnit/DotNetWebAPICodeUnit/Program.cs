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
using GRYLibrary.Core.APIServer.Settings.Configuration;
using GRYLibrary.Core.Miscellaneous.FilePath;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            return GRYLibrary.Core.APIServer.Utilities.Tools.RunAPIServer<CodeUnitSpecificCommandlineParameter, CodeUnitSpecificConstants, CodeUnitSpecificConfiguration>(GeneralConstants.CodeUnitName, CodeUnitSpecificConstants.AppDescription, Version3.Parse(GeneralConstants.CodeUnitVersion), GetEnvironmentTargetType(), GUtilities.GetExecutionMode(), commandlineArguments, (apiServerConfiguration) =>
            {
                apiServerConfiguration.SetInitialzationInformationAction = (initializationInformation) => //HINT initialization for first execution
                {
                    initializationInformation.ApplicationConstants.CommonRoutes = new HostCommonRoutes();
                    initializationInformation.ApplicationConstants.RequestLoggingMiddleware = typeof(RequestLoggingMiddleware);
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation = new CommonRoutesInformation()
                    {
                        ContactLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/Contact",
                        LicenseLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/License",
                        TermsOfServiceLink = $"https://information.{GeneralConstants.Domain}/Products/{GeneralConstants.CodeUnitName}/TermsOfService"
                    };
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeBool = true;
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeInt = 42;
                    initializationInformation.InitialApplicationConfiguration.ApplicationSpecificConfiguration.SomePropertyOfTypeString = "some string value";
                    string domain;
                    if (initializationInformation.ApplicationConstants.Environment is Development)
                    {
                        domain = $"{GeneralConstants.CodeUnitName.ToLower()}.test.local";
                    }
                    else
                    {
                        domain = "myservicedomain.example.com";//HINT this value must be updated before running but can also be changed after deployment
                    }
                    bool useHTTPS = true;//HINT this value can be updated before running but can also be changed after deployment
                    if (useHTTPS)
                    {
                        initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Protocol = HTTPS.Create(new TLSCertificateInformation
                        {
                            CertificatePFXFile = AbstractFilePath.FromString($"./{domain}.pfx"),
                            CertificatePasswordFile = AbstractFilePath.FromString($"./{domain}.password"),
                        });
                    }
                    else
                    {
                        initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Protocol = HTTP.Create();
                    }
                    initializationInformation.InitialApplicationConfiguration.ServerConfiguration.Domain = domain;
                };
                apiServerConfiguration.SetFunctionalInformationAction = (functionalInformation) => //HINT initialization for every execution
                {
                    functionalInformation.ServiceCollection.AddSingleton<ISomeService, SomeService>();
                    functionalInformation.ServiceCollection.AddSingleton<ISomeBackgroundService, SomeBackgroundService>();
                    functionalInformation.ServiceCollection.AddSingleton<ICommonRoutesInformation>(functionalInformation.PersistedAPIServerConfiguration.ApplicationSpecificConfiguration.CommonRoutesInformation);
                    ServiceProvider serviceProvider = functionalInformation.ServiceCollection.BuildServiceProvider();
                    ISomeBackgroundService someBackgroundService = serviceProvider.GetService<ISomeBackgroundService>();
                    functionalInformation.PreRun = () =>
                    {
                        someBackgroundService.StartAsync();
                    };
                    functionalInformation.PostRun = () =>
                    {
                        someBackgroundService.Stop();
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

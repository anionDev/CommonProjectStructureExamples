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

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            return GRYLibrary.Core.APIServer.Utilities.Tools.RunAPIServer<CodeUnitSpecificCommandlineParameter, CodeUnitSpecificConstants, CodeUnitSpecificConfiguration>(GeneralConstants.CodeUnitName, CodeUnitSpecificConstants.AppDescription, Version3.Parse(GeneralConstants.CodeUnitVersion), GetEnvironmentTargetType(), GUtilities.GetExecutionMode(), commandlineArguments, (apiServerConfiguration) =>
            {
                apiServerConfiguration.SetInitialzationInformationAction = (initializationInformation) =>
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
                };
                apiServerConfiguration.SetFunctionalInformationAction = (functionalInformation) =>
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

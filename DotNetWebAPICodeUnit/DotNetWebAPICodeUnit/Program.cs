using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using GRYLibrary.Core.GenericWebAPIServer.ConcreteEnvironments;
using GRYLibrary.Core.GenericWebAPIServer.ExecutionModes;
using GRYLibrary.Core.GenericWebAPIServer.Services;
using GRYLibrary.Core.GenericWebAPIServer.Settings;
using GRYLibrary.Core.GenericWebAPIServer;
using GRYLibrary.Core.Log;
using GRYLibrary.Core.Miscellaneous;
using DotNetWebAPICodeUnit.Core.Constants;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            GRYConsoleApplication<CommandlineParameter> gryConsoleApplication = new GRYConsoleApplication<CommandlineParameter>(Main,
                GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitVersion, null, false);
            return gryConsoleApplication.Main(commandlineArguments);
        }
        private static int Main(CommandlineParameter commandlineArguments)
        {
            GRYEnvironment targetEnvironmentType = GetEnvironmentTargetType();
            ExecutionMode executionMode = GenericWebAPIServer.GetExecutionMode();
            string domain = commandlineArguments.Domain;
            string programFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
            string baseFolder = GenericWebAPIServer.GetBaseFolderForProjectInCommonProjectStructure(targetEnvironmentType, programFolder);
            string configurationFolder = Path.Combine(baseFolder, "Configuration");
            string logFolder = Path.Combine(baseFolder, "Log");
            string logFile = Path.Join(logFolder, $"{GeneralConstants.CodeUnitName}.Core.log");
            string certificateFolder = Path.Combine(configurationFolder, "Certificate");
            AppConstants.DataFolder = Path.Combine(baseFolder, "Data");
            GRYLogConfiguration logConfiguration = GenericWebAPIServer.GetDefaultLogConfiguration(logFile, true, targetEnvironmentType);
            ApplicationSettings applicationSettings = new ApplicationSettings()
            {
                TermsOfServiceURL = commandlineArguments.TermsOfServiceURL,
                ContactURL = commandlineArguments.ContactURL,
                LicenseURL = commandlineArguments.LicenseURL,
                AppDescription = AppConstants.AppDescription,
                LogConfiguration = logConfiguration
            };
            WebServerSettings webServerSettings = new WebServerSettings()
            {
                Port = 443,
                TLSCertificatePasswordFile = Path.Join(certificateFolder, $"{domain}.password"),
                TLSCertificatePFXFilePath = Path.Join(certificateFolder, $"{domain}.pfx"),
                BlackListProvider = new BlacklistProvider(),
                DDOSProtectionSettings = new DDOSProtectionSettings(),
                ObfuscationSettings = new ObfuscationSettings(),
                ExceptionManagerSettings = new ExceptionManagerSettings(),
                RequestCounterSettings = new RequestCounterSettings(),
                RequestLoggingSettings = new RequestLoggingSettings() { WebServerAccessLogFile = Path.Join(logFolder, $"{GeneralConstants.CodeUnitName}.WebServerAccess.log") },
                WebApplicationFirewallSettings = new WebApplicationFirewallSettings(),
                APIKeyValidatorSettings = new APIKeyValidatorSettings(),
            };
            WebAPIConfigurationVariables webAPIConfigurationVariables = new WebAPIConfigurationVariables()
            {
                ApplicationSettings = applicationSettings,
                WebServerSettings = webServerSettings
            };

            void configureServices(IServiceCollection services)
            { }
            WebAPIConfigurationConstants webAPIConfigurationConstants = new WebAPIConfigurationConstants(
                        targetEnvironmentType,
                        GeneralConstants.CodeUnitName,
                        GeneralConstants.CodeUnitVersion,
                        Path.Combine(configurationFolder, "WebAPIServerSettings.xml"),
                        configureServices
            );
            WebAPIConfigurationValues<WebAPIConfigurationConstants, WebAPIConfigurationVariables> webAPIConfigurationValues = new WebAPIConfigurationValues<WebAPIConfigurationConstants, WebAPIConfigurationVariables>()
            {
                WebAPIConfigurationConstants = webAPIConfigurationConstants,
                WebAPIConfigurationVariables = webAPIConfigurationVariables,
                RethrowInitializationExceptions = true,
                CommandlineArguments = Array.Empty<string>(),
                ExecutionMode = executionMode
            };
            WebAPIConfiguration<WebAPIConfigurationConstants, WebAPIConfigurationVariables> webAPIConfiguration = new()
            {
                WebAPIConfigurationValues = webAPIConfigurationValues,
            };
            webAPIConfiguration.WebAPIConfigurationValues.ExecutionMode.Accept(new GenericWebAPIServer.CreateFolderVisitor(baseFolder, configurationFolder, certificateFolder, AppConstants.DataFolder));
            return GenericWebAPIServer.DefaultWebAPIMainFunction(webAPIConfiguration);
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
            throw new System.Collections.Generic.KeyNotFoundException("Unknown Environmenttype.");
#endif
        }
    }
}

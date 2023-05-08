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
using GRYLibrary.Core.GenericWebAPIServer.Settings.CommonRoutes;
using GRYLibrary.Core.GenericWebAPIServer.Utilities;
using GRYLibrary.Core.Miscellaneous.ConsoleApplication;

namespace DotNetWebAPICodeUnit.Core
{
    internal class Program
    {
        internal static int Main(string[] commandlineArguments)
        {
            ExecutionMode executionMode = ServerUtilities.GetExecutionMode();
            GRYConsoleApplication<CommandlineParameter, APIServerInitializer<AppConstants, Settings>> consoleApplication = new GRYConsoleApplication<CommandlineParameter, APIServerInitializer<CompatibilityServerConstants, Settings>>(GRYLibrary.Core.GenericWebAPIServer.APIServer<AppConstants, CompatibilityServerSettings, CommandlineParameter>.WebAPIMain, GeneralConstants.CodeUnitName, GeneralConstants.CodeUnitVersion.ToString(), CompatibilityServerConstants.AppDescription, true, executionMode);
            APIServerInitializer<AppConstants, Settings> apiServerInitializer = new APIServerInitializer<AppConstants, Settings>(GeneralConstants.CodeUnitName, Version3.Parse(GeneralConstants.CodeUnitVersion), executionMode, GetEnvironmentTargetType(), new AppConstants(), GeneralConstants.Domain, CompatibilityServerConstants.AppDescription, new CompatibilityServerSettings(), GeneralConstants.NonProductiveCertificatePasswordHex, GeneralConstants.NonProductiveCertificatePFXHex);
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

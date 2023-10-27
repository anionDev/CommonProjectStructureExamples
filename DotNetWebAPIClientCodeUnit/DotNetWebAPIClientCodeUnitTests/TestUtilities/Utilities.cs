using CCOT.DataCollector.Tests.Constants;
using System.IO;
using GUtilities = GRYLibrary.Core.Miscellaneous.Utilities;

namespace CCOT.DataCollectorClient.Tests.TestUtilities
{
    public static class Utilities
    {
        public static string GetTestServerBinary()
        {
            string binaryFile = System.Reflection.Assembly.GetEntryAssembly().Location;
            string binaryFolder = Path.GetDirectoryName(binaryFile);
            string testserverExeFile = GUtilities.ResolveToFullPath(@$"{GeneralConstants.CodeUnitFolder}\Other\Resources\DependentCodeUnits\DotNetWebAPIClient\BuildResult_DotNet_win-x64\DotNetWebAPIClient.exe", binaryFolder);
            return testserverExeFile;
        }
    }
}

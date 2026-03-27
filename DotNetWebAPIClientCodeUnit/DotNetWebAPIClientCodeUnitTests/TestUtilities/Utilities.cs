using GUtilities = GRYLibrary.Core.Misc.Utilities;

namespace DotNetWebAPIClientCodeUnit.Tests.Testcases.ClientTests
{
    public static class Utilities
    {
        public static string GetTestServerBinary()
        {
            return GUtilities.ResolveToFullPath(@$"{TestUtilities.Constants.GeneralConstants.CodeUnitFolder}\Other\Resources\DependentCodeUnits\DotNetWebAPICodeUnit\BuildResult_DotNet_win-x64\DotNetWebAPICodeUnit.exe");
        }
    }
}

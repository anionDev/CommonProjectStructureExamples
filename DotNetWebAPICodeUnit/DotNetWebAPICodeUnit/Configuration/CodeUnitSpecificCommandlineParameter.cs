using CommandLine;
using GRYLibrary.Core.Miscellaneous.ConsoleApplication;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificCommandlineParameter : ICommandlineParameter
    {
        public string[] OriginalArguments { get; set; }
        [Option(nameof(TestRun))]
        public bool TestRun { get; set; }
    }
}

using GRYLibrary.Core.Miscellaneous.ConsoleApplication;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificCommandlineParameter :ICommandlineParameter
    {
        public string[] OriginalArguments { get; set; }
    }
}

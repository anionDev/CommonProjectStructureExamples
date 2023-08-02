using GRYLibrary.Core.Miscellaneous.ConsoleApplication;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeuUnitSpecificCommandlineParameter :ICommandlineParameter
    {
        public string[] OriginalArguments { get; set; }
    }
}

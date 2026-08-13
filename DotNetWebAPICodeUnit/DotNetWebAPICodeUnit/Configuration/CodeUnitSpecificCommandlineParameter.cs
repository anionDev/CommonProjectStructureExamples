using CommandLine;
using GRYLibrary.Core.APIServer.Verbs;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificCommandlineParameter : RunServer
    {
        /// <summary>
        /// Lets the server run as a test-instance.
        /// </summary>
        /// <remarks>
        /// The option has to be declared here because "RunServer" does not declare it, while the library decides by
        /// exactly this argument that the executionmode is a testrun (see Utilities.GetExecutionMode) and its own
        /// test-helper starts a server with it. Without the declaration the argument-parser rejects the argument and
        /// the server stops before it listens on its port.
        /// </remarks>
        [Option(nameof(TestRun), Required = false, Default = false)]
        public bool TestRun { get; set; }
    }
}

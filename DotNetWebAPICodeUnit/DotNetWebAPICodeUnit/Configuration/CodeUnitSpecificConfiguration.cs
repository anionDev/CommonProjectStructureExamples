using GRYLibrary.Core.APIServer.CommonRoutes;
using GRYLibrary.Core.APIServer.Mid.DLog;
using GRYLibrary.Core.APIServer.MidT.RLog;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificConfiguration : ISupportLoggingMiddleware
    {
        public ICommonRoutesInformation CommonRoutesInformation { get; set; }
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; set; }
        public IRequestLoggingConfiguration RequestLoggingConfiguration { get; set; }
        public ILoggingConfiguration ConfigurationForLoggingMiddleware { get { return this.RequestLoggingConfiguration; } }
    }
}

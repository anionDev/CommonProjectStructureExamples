using GRYLibrary.Core.APIServer.CommonRoutes;
using GRYLibrary.Core.APIServer.Mid.Logging;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificConfiguration : ISupportRequestLoggingMiddleware
    {
        public ICommonRoutesInformation CommonRoutesInformation { get; set; }
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; set; }
        public IRequestLoggingConfiguration ConfigurationForRequestLoggingMiddleware { get; set; }
    }
}

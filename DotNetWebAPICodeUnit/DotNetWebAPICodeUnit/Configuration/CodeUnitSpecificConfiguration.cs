using GRYLibrary.Core.APIServer.CommonRoutes;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificConfiguration
    {
        public ICommonRoutesInformation CommonRoutesInformation { get; set; }
        public ISomeBackgroundServiceSettings SomeBackgroundServiceSettings { get; set; }
    }
}

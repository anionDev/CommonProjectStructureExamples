using GRYLibrary.Core.APIServer.CommonRoutes;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSpecificConfiguration
    {
        public ICommonRoutesInformation CommonRoutesInformation { get; set; }
        public string SomePropertyOfTypeString { get; set; }
        public int SomePropertyOfTypeInt { get; set; }
        public bool SomePropertyOfTypeBool { get; set; }
    }
}

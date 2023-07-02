using GRYLibrary.Core.GenericWebAPIServer.CommonRoutes;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSettings
    {
        public ICommonRoutesInformation CommonRoutesInformation { get; set; }
        public string SomePropertyOfTypeString { get; set; }
        public int SomePropertyOfTypeInt { get; set; }
        public bool SomePropertyOfTypeBool { get; set; }
    }
}

using GRYLibrary.Core.GenericWebAPIServer.Settings.CommonRoutes;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class CodeUnitSettings
    {
        public CommonRoutesInformation CommonRoutesInformation { get; internal set; }
        public string SomePropertyOfTypeString { get; set; }
        public int SomePropertyOfTypeInt { get; set; }
        public bool SomePropertyOfTypeBool { get; set; }
    }
}

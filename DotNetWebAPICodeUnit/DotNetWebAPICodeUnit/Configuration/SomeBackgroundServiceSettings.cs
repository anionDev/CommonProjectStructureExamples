using GRYLibrary.Core.Log;

namespace DotNetWebAPICodeUnit.Core.Configuration
{
    public class SomeBackgroundServiceSettings: ISomeBackgroundServiceSettings
    {
        public bool Enabled { get; set; }
        public GRYLogConfiguration LogConfiguration { get; set; }
        public string SomePropertyOfTypeString { get; set; }
        public int SomePropertyOfTypeInt { get; set; }
        public bool SomePropertyOfTypeBool { get; set; }
    }
}

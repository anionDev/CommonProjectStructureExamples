using GRYLibrary.Core.APIServer.ConcreteEnvironments;

namespace DotNetConsoleCodeUnit.Core
{
    internal static class Utilities
    {
        public static ulong Add(ulong a, ulong b)
        {
            return a + b;
        }
        public static GRYEnvironment GetEnvironmentTargetType()
        {
#if Development
            return Development.Instance;
#elif QualityCheck
            return QualityCheck.Instance;
#elif Productive
            return Productive.Instance;
#else
            throw new System.Collections.Generic.KeyNotFoundException("Unknown environmenttargettype.");
#endif
        }
    }
}

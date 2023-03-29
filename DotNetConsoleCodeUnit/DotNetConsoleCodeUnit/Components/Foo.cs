using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetLibraryCodeUnit.Core.Components
{
    public class Foo
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
        internal static int Sub(int a, int b)
        {
            return a - b;
        }
    }
}

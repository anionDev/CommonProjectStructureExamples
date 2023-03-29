using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConsoleCodeUnit.Core
{
    internal class Program
    {
        public static int Main(string[] arguments)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"This codeunit uses {DotNetLibraryCodeUnit.Core.Constants.PublicConstants.CodeUnitName} v{DotNetLibraryCodeUnit.Core.Constants.PublicConstants.CodeUnitVersion}.");
            return 0;
        }
    }
}

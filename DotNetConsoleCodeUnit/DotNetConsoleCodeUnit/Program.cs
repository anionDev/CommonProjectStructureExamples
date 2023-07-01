using System;
namespace DotNetConsoleCodeUnit.Core
{
    internal class Program
    {
        public static int Main(string[] arguments)
        {
            Console.WriteLine("Hello world!");
            Console.WriteLine($"Some example function result value: {Utilities.Add(2, 3)}");
            return 0;
        }
    }
}

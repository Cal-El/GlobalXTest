using System;
using System.IO;
using System.Collections.Generic;

namespace GlobalXTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length == 1)
            {
                Console.WriteLine(NameSorter.SortNamesList(args[0]));
            }
            else
            {
                Console.WriteLine("No file path given or too many arguments");
            }
            Console.ReadKey();
        }
    }
}

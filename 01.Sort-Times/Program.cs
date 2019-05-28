using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.Sort_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> times = new SortedSet<string>(Console.ReadLine().Trim().Split().ToList());
            
            Console.WriteLine(String.Join(", ", times));
        }
    }
}

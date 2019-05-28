using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(Console.ReadLine().Trim().Split().Select(int.Parse).ToList());

            for (int i = 0; i < numbers.Count; i++) {
                if (numbers[i] % 2 == 1) {
                    numbers.RemoveAt(i);
                    i -= 1;
                }
                
            }

            for (int i = 0; i < numbers.Count; i++) {
                if (numbers[i] > Math.Ceiling(numbers.Average())) numbers[i]++;
                else if (numbers[i] <= Math.Ceiling(numbers.Average())) numbers[i]--;
            }

            Console.WriteLine(String.Join(" ",numbers));
        }
    }
}

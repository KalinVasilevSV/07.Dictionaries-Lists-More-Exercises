using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.Take_Skip_Rope
{
    //Finished
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<int> digits = new List<int>();
            List<string> symbols = new List<string>();

            for (int i = 0; i < input.Length; i++) {
                try {
                    digits.Add(int.Parse(input[i].ToString()));
                }
                catch (FormatException) {
                    symbols.Add(input[i].ToString());
                }
            }
            string symbolString = String.Join("",symbols);

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < digits.Count; i++) {
                if (i % 2 == 0) takeList.Add(digits[i]);
                else skipList.Add(digits[i]);
            }

            string result = string.Empty;
            int startIndex = 0;
            for (int i = 0; i <takeList.Count;i++) {
                result += symbolString.Substring(startIndex,(startIndex+takeList[i]>symbolString.Length?(symbolString.Length-startIndex):takeList[i]));
                startIndex += (skipList[i]+takeList[i]);
            }

            Console.WriteLine(result);
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _06.Byte_Flip
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bytes = new List<string>(Console.ReadLine().Trim().Split());

            for (int i = 0; i < bytes.Count; i++) {
                if (bytes[i].Length != 2) { bytes.RemoveAt(i); i--; }
            }

            for (int i = 0; i < bytes.Count; i++) {
                bytes[i] = bytes[i].ReverseString();
            }

            bytes.Reverse();
            
            //for (int i = 0; i < bytes.Count; i++) {
            //    bytes[i] = "0x" + bytes[i];
            //}
            
            string result = string.Empty;
            foreach (string hex in bytes) {
                result += (char)int.Parse(hex.Trim(), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            Console.WriteLine(result.Trim());
        }
    }

    static class Extensions
    {
        public static string ReverseString(this string input)
        {
            string output=string.Empty;
            for (int i = input.Length-1; i >=0 ; i--) {
                output += input[i];
            }

            return output.Trim();
        }
    }
}

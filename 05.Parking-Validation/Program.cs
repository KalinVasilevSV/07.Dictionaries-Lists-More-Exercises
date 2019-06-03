using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.Parking_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegistry = new Dictionary<string, string>();
            int entries = int.Parse(Console.ReadLine());

            for (int i = 0; i < entries; i++) {

                string[] input = Console.ReadLine().Trim().Split();
                string action = input[0];
                string username = input[1];

                if (action == "register") {
                    string licensePlate = input[2];
                    
                    //The checks have to be in this specific order. The same as in the task text.
                    if (parkingRegistry.ContainsKey(username)) {
                        Console.WriteLine($"ERROR: already registered with plate number {parkingRegistry[username]}");
                        continue;
                    }
                    else if (!licensePlate.IsValidLicensePlate()) {
                        Console.WriteLine($"ERROR: invalid license plate {licensePlate}");
                        continue;
                    }
                    else if (parkingRegistry.ContainsValue(licensePlate)) {
                        Console.WriteLine($"ERROR: license plate {licensePlate} is busy");
                        continue;
                    }
                    else {
                        parkingRegistry[username] = licensePlate;
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                }
                else if (action == "unregister") {
                    if (parkingRegistry.ContainsKey(username)) {
                        parkingRegistry.Remove(username);
                        Console.WriteLine($"user {username} unregistered successfully");
                    }
                    else {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                }
            }

            foreach (KeyValuePair<string,string> entry in parkingRegistry) {
                Console.WriteLine($"{entry.Key} => {entry.Value}");
            }
        }
    }

    // Contains extention method to check if the license plate is valid
    static class Extensions
    {
        public static bool IsValidLicensePlate(this string licensePlate)
        {
            try {
                if (!(licensePlate[0] >= 'A' && licensePlate[0] <= 'Z')) return false;
                if (!(licensePlate[1] >= 'A' && licensePlate[1] <= 'Z')) return false;
                if (!(licensePlate[6] >= 'A' && licensePlate[6] <= 'Z')) return false;
                if (!(licensePlate[7] >= 'A' && licensePlate[7] <= 'Z')) return false;
                if (int.Parse(licensePlate.Substring(2, 4)) <= 0) return false;
            }
            catch (Exception) { return false; }

            return true;
        }
    }

}

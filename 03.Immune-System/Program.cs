using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, VirusStats> immuneMemory = new SortedDictionary<string, VirusStats>();
            int immuneHealth=int.Parse(Console.ReadLine());
            int initialHealth = immuneHealth;

            while (true) {

                string virusName = Console.ReadLine();
                if (virusName == "end") break;

                if (!immuneMemory.ContainsKey(virusName)) {
                    immuneMemory[virusName] = new VirusStats(virusName);

                    Console.WriteLine($"Virus {virusName}: {immuneMemory[virusName].virusStrength} => {immuneMemory[virusName].timeToDefeat} seconds");
                    immuneHealth -= immuneMemory[virusName].timeToDefeat;
                    if (immuneHealth > 0) {
                        Console.WriteLine($"{virusName} defeated in {SecondsToString(immuneMemory[virusName].timeToDefeat)}.");
                        Console.WriteLine($"Remaining health: {immuneHealth}");
                    }
                    else {
                        Console.WriteLine("Immune System Defeated.");
                        break;
                    }
                }
                else {
                    Console.WriteLine($"Virus {virusName}: {immuneMemory[virusName].virusStrength} => {immuneMemory[virusName].timeToDefeat/3} seconds");
                    immuneHealth -= (immuneMemory[virusName].timeToDefeat/3);
                    if (immuneHealth > 0) {
                        Console.WriteLine($"{virusName} defeated in {SecondsToString(immuneMemory[virusName].timeToDefeat/3)}.");
                        Console.WriteLine($"Remaining health: {immuneHealth}");
                    }
                    else {
                        Console.WriteLine("Immune System Defeated.");
                        break;
                    }
                }

                immuneHealth += (int)(immuneHealth * 0.2);
                if (immuneHealth > initialHealth) immuneHealth = initialHealth;
            }
            if (immuneHealth > 0) {
                Console.WriteLine($"Final Health: {immuneHealth}");
            }
        }

        class VirusStats
        {
            public int virusStrength = 0;
            public int timeToDefeat=0;

            public VirusStats(string virusName)
            {
                this.virusStrength = (StringToArray(virusName).Sum()) / 3;
                this.timeToDefeat = virusStrength * virusName.Length;
            }
        }

        public static string SecondsToString(int seconds)
        {
            string time = string.Empty;
            return time = (seconds / 60).ToString() + "m "+(seconds%60).ToString()+"s";
        }

        public static int[] StringToArray(string input)
        {
            int[] array= new int[input.Length];
            for (int i = 0; i < input.Length; i++) {
                array[i] = input[i];
            }
            return array;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Day04_PassportProcessing
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(@"--- Day 4:  Passport Processing ---");
            List<Passport> passports = ReadFile();

            // Count number of valid passports
            var countValidPassports = 0;

            // print out out the passport items to verify if the batch input file is reading correctly
            // associative arrays are a glory of the intrepreted languages.
            // in C# they are difficult to work with because of the strict type checking
            foreach (var passport in passports)
            {
                if (passport.IsComplete())
                {
                    countValidPassports += 1;
                }
                System.Console.WriteLine($"Passport complete?  {passport.IsComplete()}");
                System.Console.WriteLine($"Count of passport fields {passport.PassportItems.Count}");
                foreach (KeyValuePair<string, string> kvp in passport.PassportItems)
                {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                Console.WriteLine();
            }

            // Puzzle 1:  number of valid passports in batch job
            System.Console.WriteLine($"Number of valid passports in batch job is:  {countValidPassports}");
        }

        // read in puzzle data and create a List of type Passport
        public static List<Passport> ReadFile()
        {
            string line;
            var passports = new List<Passport>();

            using (StreamReader file = new StreamReader(@"PuzzleInput.txt"))
            {
                Passport p = new Passport();

                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        string[] fields = line.Split(' ');

                        foreach (string f in fields)
                        {
                            string[] kv = f.Split(':');
                            p.PassportItems[kv[0].Trim()] = kv[1].Trim();
                        }
                    }
                    else
                    {
                        passports.Add(p);
                        p = new Passport();
                    }
                }
            }

            return passports;
        }

    }

}

using System;
using System.Collections.Generic;
using System.IO;

namespace Day04_PassportProcessing
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(@"--- Day 4:  Passport Processing ---");
            List<Passportz> passports = ReadFile();

            // print out out the passport items to verify if the batch input file is reading correctly
            // associative arrays are a glory of the intrepreted languages.
            // in C# they are difficult to work with because of the strict type checking
            foreach (var passport in passports)
            {
                System.Console.Write(passport.IsComplete());
                foreach (KeyValuePair<string, string> kvp in passport.PassportItems)
                {
                    Console.Write("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                }
                Console.WriteLine();
            }
        }

        public static List<Passportz> ReadFile()
        {
            string line;
            var passports = new List<Passportz>();

            using (StreamReader file = new StreamReader(@"PuzzleInputFromProblemDescr.txt"))
            {
                Passportz p = new Passportz();

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
                        p = new Passportz();
                    }
                }
            }

            return passports;
        }

    }
}

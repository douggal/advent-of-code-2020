using System;
using System.IO;
using System.Collections.Generic;
using Day02_PasswordPhilosophy;

namespace Day02_PasswordPhilosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"--- Day 2: Password Philosophy ---");

            var rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile();

            // Puzzle 1:  how many passwords are valid?
            var countValidPasswords = Puzzle1(inputFile);
            System.Console.WriteLine($"\n\nPuzzle 1 count of valid passwords is: {countValidPasswords}");

            // Puzzle 2:  new rules!  how many passwords are valid using new intrepreation of rule?
            countValidPasswords = Puzzle2(inputFile);
            System.Console.WriteLine($"\n\nPuzzle 2 count of valid passwords is: {countValidPasswords}");

        }

        public static int Puzzle2(List<string> inputFile)
        {
            var countValidPasswords = 0;

            foreach (var line in inputFile)
            {
                string[] tokens = line.Split(' ');

                //Console.WriteLine($"{tokens[0]} | {tokens[1]} | {tokens[2]}");

                //Token 0:  password rule   <min> - <max> times char can appear in password
                //Token 1:  character rule applies to
                //Token 2:  password

                var first = int.Parse(tokens[0].Split('-')[0]) - 1;
                var second = int.Parse(tokens[0].Split('-')[1]) - 1;
                string findThisChar = tokens[1];
                char[] p = tokens[2].ToCharArray();

                bool notBoth = p[first] != p[second];

                if ((p[first] == findThisChar[0] || p[second] == findThisChar[0]) && notBoth)
                {
                    countValidPasswords++;
                    //Console.WriteLine($"Valid: {tokens[0]} | {tokens[1]} | {tokens[2]}");
                }
                else
                {
                    //Console.WriteLine($"Invalid: {tokens[0]} | {tokens[1]} | {tokens[2]}");
                }

            }

            return countValidPasswords;

        }

        public static int Puzzle1(List<String> inputFile)
        {
            var countValidPasswords = 0;

            foreach (var line in inputFile)
            {
                string[] tokens = line.Split(' ');

                //Console.WriteLine($"{tokens[0]} | {tokens[1]} | {tokens[2]}");

                //Token 0:  password rule   <min> - <max> times char can appear in password
                //Token 1:  character rule applies to
                //Token 2:  password

                var min = int.Parse(tokens[0].Split('-')[0]);
                var max = int.Parse(tokens[0].Split('-')[1]);
                string findThisChar = tokens[1];
                char[] p = tokens[2].ToCharArray();

                var charCount = 0;

                foreach (var c in p)
                {
                    if (c == findThisChar[0])
                    {
                        charCount++;
                    }
                }

                if (charCount >= min && charCount <= max)
                {
                    countValidPasswords++;
                    //Console.WriteLine($"Valid: {tokens[0]} | {tokens[1]} | {tokens[2]}");
                }
                else
                {
                    //Console.WriteLine($"Invalid: {tokens[0]} | {tokens[1]} | {tokens[2]}");
                }

            }

            return countValidPasswords;

        }

    }
}

using System;
using System.Collections.Generic;

namespace Day09_EncodingError
{
    class Program
    {
        static void Main(string[] args)
        {
            // Advent of Code 2020  Day 9 Puzzle Encoding Error   https://adventofcode.com


            Console.WriteLine(@"--- Day 9: Encoding Error ---");

            var rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile();

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");

            // What is the first number in the input stream that is not the sum of two different previous numbers (cannot be same number twice).
            // within the preamble "window" size.

            var preambleCount = 25;
            var found = false;

            List<double> validNbrs = new List<double>();

            for (int i = preambleCount; i < inputFile.Count; i++)   //note start one item past the preamble count
            {
                validNbrs.Clear();
                for (int j = i-preambleCount; j < i; j++)
                {
                    for (int k = i-preambleCount; k < i; k++)
                    {
                        validNbrs.Add(inputFile[j] + inputFile[k]);
                    }
                }
                if (!validNbrs.Contains(inputFile[i]))
                {
                    found = true;
                    Console.WriteLine($"Part 1: first number in the input stream that is not sum of any two different numbers in previous {preambleCount} numbers is: {inputFile[i]} index = {i}");
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Part 1:  scanned list and did not find any number that is is not sum of two of previous {preambleCount} numbers.");
            }
        }

    }
}

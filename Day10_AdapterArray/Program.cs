using System;

namespace Day10_AdapterArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // Advent of Code 2020  Day 10 Puzzle Adapter Array   https://adventofcode.com
            // 12/10/2020

            Console.WriteLine(@"--- Day 10: Adapter Array ---");

            var rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile();

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");
        }
    }
}

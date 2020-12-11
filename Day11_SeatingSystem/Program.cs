using System;

namespace Day11_SeatingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Advent of Code 2020  Day 11 Seating System   https://adventofcode.com
            // 12/11/2020

            Console.WriteLine(@"--- Day 11: Seating System ---");

            var rf = new ReadPuzzleInputFile();
            var adapters = rf.ReadFile();

            // adapters is a list of integers.  Each integer represents an adapter's jolts. 
            //No other info is provided and adapters are known only by their postion or index in this list.

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");
        }
    }
}

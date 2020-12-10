using System;
using System.Collections.Generic;
using System.Numerics;

namespace Day09_EncodingError
{
    class Program
    {
        static void Main(string[] args)
        {
            // Advent of Code 2020  Day 9 Puzzle Encoding Error   https://adventofcode.com
            // 12/9/2020
            // Surprise! the input file has some really big integers.  Use System.Numerics BigInteger type
            //

            Console.WriteLine(@"--- Day 9: Encoding Error ---");

            var rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile();

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");

            // What is the first number in the input stream that is not the sum of two different previous numbers (cannot be same number twice).
            // within the preamble "window" size.

            var preambleCount = 25;
            var found = false;
            BigInteger thisNumber = 0;
            int thisIndex = -1;

            found = Part1(inputFile, preambleCount, ref thisNumber, ref thisIndex);

            if (found)
            {
                found = true;
                Console.WriteLine($"Part 1: first number in the input stream that is not sum of any two different numbers in previous {preambleCount} numbers is: {thisNumber} index = {thisIndex}");
            }

            if (!found)
            {
                Console.WriteLine($"Part 1:  Fail!. Scanned list and did not find any number that is is not sum of two of previous {preambleCount} numbers.");
            }

            //part 2:
            BigInteger sumSmallAndLarge = 0;
            sumSmallAndLarge = Part2(inputFile, preambleCount, thisNumber, thisIndex);
            if (sumSmallAndLarge != 0)
            {
                Console.WriteLine($"Part 2: sum smallest and largest numbers in the contiguous sequence which adds to {thisNumber} is {sumSmallAndLarge}");
            }
            else
            {
                Console.WriteLine("Fail! didn't find anything.");
            }
        }



        private static BigInteger Part2(List<BigInteger> inputFile, int preambleCount, BigInteger thisNumber, int thisLocation)
        {
            List<BigInteger> validNbrs = new List<BigInteger>();
            BigInteger sumSmallAndLarge = 0;
            BigInteger sum = 0;

            for (int i = 0; i < inputFile.Count; i++)   //note start one item past the preamble count
            {
                validNbrs.Clear();
                sum = inputFile[i];
                validNbrs.Add(inputFile[i]);
                for (int j = i+1; j < inputFile.Count; j++)
                {
                    validNbrs.Add(inputFile[j]);
                    sum += inputFile[j];
                    if (sum == thisNumber)
                    {
                        validNbrs.Sort();
                        sumSmallAndLarge = validNbrs[0] + validNbrs[validNbrs.Count-1];
                        return sumSmallAndLarge;
                    }
                }
            }

            return 0;
        }


        private static bool Part1(List<BigInteger> inputFile, int preambleCount, ref BigInteger thisNumber, ref int thisLocation)
        {
            List<BigInteger> validNbrs = new List<BigInteger>();
            var found = false;

            for (int i = preambleCount; i < inputFile.Count; i++)   //note start one item past the preamble count
            {
                validNbrs.Clear();
                for (int j = i - preambleCount; j < i; j++)
                {
                    for (int k = i - preambleCount; k < i; k++)
                    {
                        validNbrs.Add(inputFile[j] + inputFile[k]);
                    }
                }
                if (!validNbrs.Contains(inputFile[i]))
                {
                    found = true;
                    thisNumber = inputFile[i];
                    thisLocation = i;
                    break;
                }
        }

            return found;
        }
    }
}

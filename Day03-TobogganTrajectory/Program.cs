using System;
using System.IO;
using System.Collections.Generic;

namespace Day03_TobogganTrajectory
{
    class Program
    {
        const char tree = '#';
        const char open = '.';

        static void Main(string[] args)
        {
            // Advent of Code 2020  Day 3 Puzzle   https://adventofcode.com


            Console.WriteLine(@"--- Day 3: Toboggan Trajectory ---");

            // to solve this puzzle I had what i thought was a brilliant idea at the start.
            // I'd represent each row of the terrain map as a circular array of char
            // Since the terrain exends to the right indefinately it should work
            // In the end I felt I'd written more code than really should have needed
            // to come up with an answer.  The use of Generics saves me having
            // to care about actual number of rows in the puzzle input file,
            // and while a screwdriver isn't always best tool for the job if that's
            // what you have, use it.
            //
            // puzzle input is modelled as a circular array (endless grid) representing a patch of terrain
            // the terrain repeats to the right
            // I'll model the terrain map as a List of these one dimensional circular arrays

            var rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile();

            List<CircularArrayOfChar> map = LoadMap(inputFile);

            // use text compare tool to validate input file was correctly read in
            // and matches puzzle terrain
            // PrintMap(map); 

            // puzzle 1 slope is a given:  right = 3, down = 1
            TallyOfResults results = Puzzle1(map, 3, 1);
            Console.WriteLine($"Puzzle 1 tree hits = {results.TreeHits}");
            Console.WriteLine($"Puzzle 1 open space hits = {results.OpenSpaceHits}");
            Console.WriteLine($"Puzzle 1 final value to the right = {results.ReachRight}");

            // puzzle 2 test cases are
            // Right 1, down 1.
            // Right 3, down 1. (This is the slope you already checked.)
            // Right 5, down 1.
            // Right 7, down 1.
            // Right 1, down 2.
            // Puzzle1 will solve Puzzle2 just different input values for slope

            int[,] testCases = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };

            List<TallyOfResults> resultsp2 = new List<TallyOfResults>();

            for (int i = 0; i < 5; i++)
            {
                results = Puzzle1(map, testCases[i, 0], testCases[i, 1]);
                Console.WriteLine($"Puzzle 2 test run {i} slope = ({testCases[i, 0]},{testCases[i, 1]}): tree hits = {results.TreeHits}");
                Console.WriteLine($"Puzzle 2 test run {i}: open space hits = {results.OpenSpaceHits}");
                Console.WriteLine($"Puzzle 2 test run {i}: final value to the right = {results.ReachRight}");

                resultsp2.Add(results);
            }

            double totalTreeHits = 1;  // i.e., init at 1:  1 multiplied by another number = other number
            foreach (var item in resultsp2)
            {
                totalTreeHits *= item.TreeHits;
            }
            Console.WriteLine($"Puzzle 2 product of treeHits for each run = {totalTreeHits}");

        }

        public static TallyOfResults Puzzle1(List<CircularArrayOfChar> map, int right, int down)
        {
            //current position
            var x = 0;   //horizontal
            var y = 0;   //vertical

            var treeHits = 0;
            var openHits = 0;

            TallyOfResults r = new TallyOfResults();

            x += right;
            y += down;
            while (y <= map.Count - 1)
            {
                if (map[y].GetValueAt(x) == tree)
                {
                    treeHits += 1;
                    //System.Console.Write("hit ");
                }
                else
                {
                    openHits += 1;
                    //System.Console.Write("mis ");
                }
                //System.Console.WriteLine($"{x},{y}");  // for debug
                x += right;
                y += down;

            }

            r.TreeHits = treeHits;
            r.OpenSpaceHits = openHits;
            r.ReachRight = x;

            return r;
        }

        public static List<CircularArrayOfChar> LoadMap(List<String> file)
        {
            List<CircularArrayOfChar> m = new List<CircularArrayOfChar>();

            // for each line file[i] of input
            //  for each character in line add the character to the map
            for (int i = 0; i < file.Count; i++)
            {
                var newRow = new CircularArrayOfChar();
                for (int j = 0; j < file[i].Length; j++)
                {
                    newRow.Add(file[i][j]);
                }
                m.Add(newRow);
            }

            return m;
        }

        public static void PrintMap(List<CircularArrayOfChar> m)
        {

            for (int i = 0; i < m.Count; i++)
            {
                for (int j = 0; j < m[i].CountOfItems(); j++)
                {
                    System.Console.Write($"{m[i].GetValueAt(j)}");
                }
                System.Console.WriteLine();
            }

            return;
        }

    }
}

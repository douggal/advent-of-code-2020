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

            var inputFile = @"PuzzleInputTest.txt";

            /*
            The following rules are applied to every seat simultaneously:

            If a seat is empty(L) and there are no occupied seats adjacent to it, 
            the seat becomes occupied.
            
            If a seat is occupied(#) and four or more seats adjacent to it are also occupied, 
            the seat becomes empty.
            
            Otherwise, the seat's state does not change.

            Floor(.) never changes; seats don't move, 
            and nobody sits on the floor.
            */


            WaitingRoom wr = new WaitingRoom();

            wr.InitializeRoom(inputFile);

            Console.WriteLine("Room: ");
            wr.PrintRoom();
            Console.WriteLine();

            // run 1 gen
            wr.GenerateNext();
            wr.PrintRoom();
            Console.WriteLine();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }



    }
}

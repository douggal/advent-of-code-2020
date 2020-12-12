using System;

namespace Day11_SeatingSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Advent of Code 2020  Day 11 Seating System   https://adventofcode.com
            // 12/11/2020

            Console.WriteLine(@"--- Day 11: Seating System ---");

            var inputFile = @"PuzzleInputTest.txt";

            /*
             * I took an object oriented C# approach. Although verbose and not efficient of CPU 
             * it is easier to write code by breaking out the problem into objects with properties and methods.
             * 
             * 
             * The following rules are applied to every seat simultaneously:
             * 
             * If a seat is empty(L) and there are no occupied seats adjacent to it, 
             * the seat becomes occupied.
             * 
             * 
            
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

            // run 9 more gens
            //var ngens = 100;
            //var prevChgState = false;
            //for (int i = 0; i < ngens; i++)
            //{
            //    prevChgState = wr.HasChanged;
            //    wr.GenerateNext();
            //    if (true || (i > 0 && prevChgState != wr.HasChanged))
            //    {
            //        Console.WriteLine($"Generation {i}:");
            //        wr.PrintRoom();
            //        //Console.WriteLine($"{wr.HasChanged}");
            //        Console.WriteLine($"Count of occupied Seats {wr.CountOfOccupiedSeats()}\n\n");

            //    }
            //    //Console.WriteLine($"{wr.HasChanged}");
            //}

            Console.WriteLine($"Count of occupied Seats {wr.CountOfOccupiedSeats()}\n\n");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }



    }
}

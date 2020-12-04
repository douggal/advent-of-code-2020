using System;
using System.IO;
using System.Collections.Generic;

namespace Day01_ReportRepair
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Read the file into a List<int>  
            List<int> expenses = ReadExpensesFile();

            // Puzzle 1:  brute force w/some thought to reduce number of iterations
            // I'm looking for the solution by squaring the array (rows and columns are same list of numbers), and
            // when thought of that way it follows that I need only check 1/2 the matrix to cover all the possiblities.
            // That is the inner loop can start at index of outer loop + 1.
            for (int i = 0; i < expenses.Count; i++)
            {
                var p = expenses[i];
                for (int j = i + 1; j < expenses.Count; j++)
                {
                    var q = expenses[j];
                    if (p + q == 2020)
                    {
                        Console.WriteLine($"{p,10} + {q,10} = {p + q,10} and multiplied together the product is {p * q,10}");
                    }
                }
            }

            //Puzzle 2:
            // Ditto solution for Puzzle 1, and I considered each the 3rd dimension as a slice
            // consisting of the array of expenses x same array as in Puzzle 1.
            for (int k = 0; k < expenses.Count; k++)
            {
                var r = expenses[k];

                for (int i = k+1; i < expenses.Count; i++)
                {
                    var p = expenses[i];

                    for (int j = i + 1; j < expenses.Count; j++)
                    {
                        var q = expenses[j];

                        if (p + q + r == 2020)
                        {
                            Console.WriteLine($"{p,7} + {q,7} + {r,7} = {p + q + r,10} and multiplied together the product is {p * q * r,10}");
                        }
                    }
                }
            }

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
        }

        public static List<int> ReadExpensesFile() {
            int counter = 0;
            string line;
            List<int> expenses = new List<int>();

            using (StreamReader file = new StreamReader(@"Expenses.txt"))
            {
                int i;
                while ((line = file.ReadLine()) != null)
                {
                    if (int.TryParse(line.Trim(), out i))
                    {
                        expenses.Add(i);
                    }
                    Console.WriteLine(line);
                    counter++;
                }
            }

            return expenses;
        }

    }
}

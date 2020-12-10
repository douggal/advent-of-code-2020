using System;
using System.Collections.Generic;
using System.Text;

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
            var adapters = rf.ReadFile();

            // adapters is a list of integers.  Each integer represents an adapter's jolts. 
            //No other info is provided and adapters are known only by their postion or index in this list.

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");

            List<int> testChain;

            List<StringBuilder> triedTheseChains = new List<StringBuilder>();

            adapters.Sort();  // sort the adapter list ascending


            // algorithm:  Brute Force!
            // check everything until first valid chain of adapters is found or we run out of adapter chains to check

            testChain = new List<int>();
            testChain.Add(0); // always start at 0

            bool testComplete = false;
            int thisAdapter = 0;  // index of this adapter in list of adapters
            bool foundChain = false;
            List<int> next3;

            // build a chain one element at a time
            do
            {
                thisAdapter += 1;

                next3 = FindNext3(adapters, thisAdapter);  // List<int> with 0 to 3 

                next3.Sort();

                // try to add another item
                var fail = false;  //optimistic
                if (next3.Count > 0)
                {
                    var addThisItem = 0;
                    int i;
                    for (i = 0; i < next3.Count; i++)
                    {
                        var tmpChain = new List<int>();
                        for (int j = 0; j < testChain.Count; j++)
                        {
                            tmpChain.Add(testChain[j]);
                        }
                        tmpChain.Add(next3[i]);
                        if (IsThisANewChain(triedTheseChains, tmpChain))
                        {
                            addThisItem = i;
                            break;
                        }
                    }
                    if (i < next3.Count)
                    {
                        testChain.Add(next3[addThisItem]);
                    } else
                    {
                        fail = true;
                    }
                }

                if (fail)
                {
                    AddDeadEnd(triedTheseChains, testChain);
                    testComplete = true;
                }


            } while (!testComplete && thisAdapter < adapters.Count);

            if (testChain.Count >= adapters.Count)
            {
                foundChain = true;
            }
            else
            {
                // add this test case to list of those tried.
                AddDeadEnd(triedTheseChains, testChain);
            }

            if (foundChain)
            {
                Console.WriteLine($"Found chain");
            }
            else
            {
                Console.WriteLine($"Did not find chain");
            }


            Console.WriteLine("Done.  Press any key to exit");
            Console.ReadKey();

        }

        private static bool IsThisANewChain(List<StringBuilder> triedTheseChains, List<int> tmpChain)
        {
            var result = false;
            var tChain = new StringBuilder();
            for (int i = 0; i < tmpChain.Count; i++)
            {
                tChain.Append(tmpChain[i].ToString());
            }

            foreach (var item in triedTheseChains)
            {
                if (item.ToString() == tChain.ToString() ) {
                    result = true;
                }
            }
            return result;
        }

        private static void AddDeadEnd(List<StringBuilder> triedTheseChains, List<int> testChain)
        {

            triedTheseChains.Add(new StringBuilder());
            var idx = triedTheseChains.Count - 1;

            for (int i = 0; i < testChain.Count; i++)
            {
                triedTheseChains[idx].Append(testChain[idx].ToString());
            }
            return;
        }

        private static List<int> FindNext3(List<int> adapters, int start)
        {
            var result = new List<int>();
            int end = start + 3;

            for (int i = 0; i < adapters.Count && i < end; i++)
            {
                result.Add(adapters[i]);
            }
            return result;
        }
    }
}

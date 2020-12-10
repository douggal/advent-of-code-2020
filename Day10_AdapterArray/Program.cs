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

            AdapterChain candidateChain;

            List<StringBuilder> deadEndChains = new List<StringBuilder>();

            adapters.Sort();  // sort the adapter list ascending


            // algorithm:  Brute Force!
            // check everything and build up a list of valid chains until we find a complete chain from wall to device.
            candidateChain = new AdapterChain();
            candidateChain.Chain.Add(0); // always start at 0

            bool testComplete = false;
            int thisAdapter = 0;  // start at the wall always, add index of this adapter in list of adapters
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
                        for (int j = 0; j < candidateChain.Chain.Count; j++)
                        {
                            tmpChain.Add(candidateChain.Chain[j]);
                        }
                        tmpChain.Add(next3[i]);
                        if (IsThisANewChain(deadEndChains, tmpChain))
                        {
                            addThisItem = i;
                            break;
                        }
                    }
                    if (i < next3.Count)
                    {
                        candidateChain.Chain.Add(next3[addThisItem]);
                    } else
                    {
                        fail = true;
                    }
                }

                if (fail)
                {
                    // add this test case to list of those tried.
                    AddDeadEnd(deadEndChains, candidateChain);
                    testComplete = true;
                }


            } while (!testComplete && thisAdapter < adapters.Count);

            if (candidateChain.Chain.Count == adapters.Count+1)  // candidate chain will include wall +1 for items count.
            {
                foundChain = true;
            }

            if (foundChain)
            {
                Console.WriteLine($"Found chain");

                PrintChainToConsole(candidateChain);
            }
            else
            {
                Console.WriteLine($"Did not find chain");
            }


            Console.WriteLine("Done.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void PrintChainToConsole(AdapterChain candidateChain)
        {
            // print chain
            for (int i = 0; i < candidateChain.Chain.Count; i++)
            {
                if ( i < candidateChain.Chain.Count-1)
                {
                    Console.Write($"{candidateChain.Chain[i]},");
                }
                else
                {
                    Console.WriteLine($"{candidateChain.Chain[i]}");
                }
            }
        }

        private static bool IsThisANewChain(List<StringBuilder> triedTheseChains, List<int> tmpChain)
        {
            var result = true;
            var tChain = new StringBuilder();
            for (int i = 0; i < tmpChain.Count; i++)
            {
                tChain.Append(tmpChain[i].ToString());
            }

            foreach (var item in triedTheseChains)
            {
                if (String.Compare(item.ToString(), tChain.ToString()) == 0 ) {
                    result = false;  // not a new chain it's one we have already tried out.
                    break;
                }
            }
            return result;
        }

        private static void AddDeadEnd(List<StringBuilder> triedTheseChains, AdapterChain testChain)
        {

            triedTheseChains.Add(new StringBuilder());
            var idx = triedTheseChains.Count - 1;

            for (int i = 0; i < testChain.Chain.Count; i++)
            {
                triedTheseChains[idx].Append(testChain.Chain[i].ToString());
            }
            return;
        }

        private static List<int> FindNext3(List<int> adapters, int start)
        {
            var result = new List<int>();
            int end = start + 2;

            // start is one ahead of 0 based list count, subtract 1 to get index number
            for (int i = start-1; i < adapters.Count && i <= end; i++)
            {
                result.Add(adapters[i]);
            }
            return result;
        }
    }
}

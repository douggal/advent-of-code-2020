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

                FindDistribution(candidateChain);

            }
            else
            {
                Console.WriteLine($"Did not find chain");
            }




            ///////////////////////////////////////////////
            // part 2:  how many valid combos are there?
            Console.WriteLine($"\nPart 2.");

            // algorthm:  at each node in the chain there are only so many valid adapters to choose from.
            //  record how many are available.

            List<int> validCombos = new List<int>();

            next3.Clear();

            adapters.Insert(0, 0); // add wall outlet.

            // build a chain one element at a time
           for (thisAdapter = 0; thisAdapter < adapters.Count; thisAdapter++) 
           { 
                next3 = FindNext3a(adapters, thisAdapter);  // List<int> with 0 to 3 

                if (next3.Count > 0)  validCombos.Add(next3.Count);  // last item count will be 0 choices to device itself

            };

            double p = 1d;
            for (int i = 0; i < validCombos.Count; i++)
            {
                if (i < validCombos.Count - 1)
                {
                    Console.Write($"{validCombos[i]},");
                }
                else
                {
                    Console.WriteLine($"{validCombos[i]}");
                }

                p *= validCombos[i];

            }
            Console.WriteLine($"Count of valid adapter combos is {p}");

            Console.WriteLine("Done.");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void FindDistribution(AdapterChain candidateChain)
        {
            Dictionary<int, int> dist = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };

            var d = 0;
            var c = 0; // for debug count items incl in distro should equal #items in chain-1 + 1 additional item the device itself

            // for each item find joltage diff between it and its previous item
            for (int i = 1; i < candidateChain.Chain.Count; i++)
            {
                c += 1;
                d = candidateChain.Chain[i] - candidateChain.Chain[i - 1];
                if (d > 3 || d < 1) { Console.WriteLine("Error"); }
                else
                {
                    dist[d] = dist[d] + 1;
                }
            }
            c += 1;
            dist[3] = dist[3] + 1;  // add diff between device and last adapter in the chain.  it's always +3

            //print joltage distro
            foreach (KeyValuePair<int, int> entry in dist)
            {
                Console.WriteLine($"{entry.Key.ToString()}, diff {entry.Value.ToString()}");
            }

            // print product of +1 count by +3 count
            Console.WriteLine($"Product of +1 count x +3 count is {dist[1]} * {dist[3]} = {dist[1]*dist[3]}.  Items in distro is {c}");
            return;
        }

        private static void PrintChainToConsole(AdapterChain candidateChain)
        {

            Console.WriteLine($"Item count: {candidateChain.Chain.Count}");

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
            for (int i = start-1; i < adapters.Count && i < end; i++)
            {
                result.Add(adapters[i]);
            }

            result.Sort();

            return result;
        }

        private static List<int> FindNext3a(List<int> adapters, int startIdx)
        {
            var result = new List<int>();
            int end = startIdx + 3;

            // start is one ahead of 0 based list count, subtract 1 to get index number
            for (int i = startIdx+1; i < adapters.Count && i < end; i++)
            {
                var d = adapters[i] - adapters[startIdx];
                if (d >= 1 && d <= 3) result.Add(adapters[i]);
            }

            result.Sort();

            return result;
        }
    }
}

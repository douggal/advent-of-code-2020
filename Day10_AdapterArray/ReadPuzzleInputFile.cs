using System;
using System.IO;
using System.Collections.Generic;

namespace Day10_AdapterArray
{
    public class ReadPuzzleInputFile
    {
        public int LinesRead { get; set; }
        public ReadPuzzleInputFile()
        {
            LinesRead = 0;
        }

        public List<int> ReadFile()
        {
            string line;
            var lines = new List<int>();

            using (StreamReader file = new StreamReader(@"PuzzleInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        lines.Add(int.Parse(line.Trim()));
                    }
                }
            }

            LinesRead = lines.Count;

            return lines;
        }

    }
}
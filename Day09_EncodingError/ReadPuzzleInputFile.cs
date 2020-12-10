using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace Day09_EncodingError
{
    public class ReadPuzzleInputFile
    {
        public int LinesRead { get; set; }
        public ReadPuzzleInputFile()
        {
            LinesRead = 0;
        }

        public List<BigInteger> ReadFile()
        {
            string line;
            var lines = new List<BigInteger>();

            using (StreamReader file = new StreamReader(@"PuzzleInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        lines.Add(BigInteger.Parse(line.Trim()));
                    }
                }
            }

            LinesRead = lines.Count;

            return lines;
        }

    }
}
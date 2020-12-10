using System;
using System.IO;
using System.Collections.Generic;


namespace Day09_EncodingError
{
    public class ReadPuzzleInputFile
    {
        public int LinesRead { get; set; }
        public ReadPuzzleInputFile()
        {
            LinesRead = 0;
        }

        public List<double> ReadFile()
        {
            string line;
            var lines = new List<double>();

            using (StreamReader file = new StreamReader(@"PuzzleInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        lines.Add(double.Parse(line.Trim()));
                    }
                }
            }

            LinesRead = lines.Count;

            return lines;
        }

    }
}
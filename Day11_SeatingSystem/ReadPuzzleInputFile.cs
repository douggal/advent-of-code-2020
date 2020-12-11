using System;
using System.IO;
using System.Collections.Generic;

namespace Day11_SeatingSystem
{
    public class ReadPuzzleInputFile
    {
        public int LinesRead { get; set; }
        public ReadPuzzleInputFile()
        {
            LinesRead = 0;
        }

        public List<string> ReadFile(string fn)
        {
            string line;
            var lines = new List<string>();

            using (StreamReader file = new StreamReader(fn))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        lines.Add(line.Trim());
                    }
                }
            }

            LinesRead = lines.Count;

            return lines;
        }

    }
}
using System;
using System.IO;
using System.Collections.Generic;


namespace Day02_PasswordPhilosophy
{
    public class ReadPuzzleInputFile
    {

        public ReadPuzzleInputFile()
        {

        }

        public List<String> ReadFile()
        {
            int counter = 0;
            string line;
            var lines = new List<String>();

            using (StreamReader file = new StreamReader(@"PuzzleInput.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Trim().Length > 0)
                    {
                        lines.Add(line.Trim());
                    }
                    counter++;
                }
            }

            return lines;
        }



    }
}
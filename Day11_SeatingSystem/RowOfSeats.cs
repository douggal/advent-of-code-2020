using System;
using System.Collections.Generic;
using System.Text;

namespace Day11_SeatingSystem
{
    public class RowOfSeats
    {
        public List<Seat> Row { get; set; }

        public RowOfSeats()
        {
            Row = new List<Seat>();
        }
    }
}

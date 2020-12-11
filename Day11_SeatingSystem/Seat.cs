using System;
using System.Collections.Generic;
using System.Text;

namespace Day11_SeatingSystem
{
    public class Seat
    {

        const char _seatEmpty = 'L';
        const char _seatOccupied = '#';
        const char _seatOpenFloor = '.';


        private Tuple<int, int> _seatNumber;
                
        public Tuple<int, int> SeatNumber
        {
            get { return _seatNumber; }
            set { _seatNumber = value; }
        }


        public char State { get; set; }

        public Seat(int row, int col)
        {
            State = ' ';
            SeatNumber = new Tuple<int, int>( row, col );
        }
    }
}

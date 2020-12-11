using System;
using System.Collections.Generic;
using System.Text;

namespace Day11_SeatingSystem
{
    public class WaitingRoom
    {

        List<RowOfSeats> _nextGenRoom;

        public bool HasChanged { get; set; }

        public List<RowOfSeats> Room { get; set; }

        public WaitingRoom()
        {
            HasChanged = true;
            Room = new List<RowOfSeats>();
        }

        public void InitializeRoom(string filenm)
        {
            ReadPuzzleInputFile rf = new ReadPuzzleInputFile();
            var inputFile = rf.ReadFile(filenm);
            RowOfSeats new_row;

            // build a waiting room...
            var r = 0;
            var c = 0;
            foreach (var line in inputFile)
            {
                new_row = new RowOfSeats();
                char[] s = line.ToCharArray();
                
                foreach (var ch in s)
                {
                    var new_seat = new Seat(r, c);
                    new_seat.State = ch;
                    //if (ch != 'L' || ch != '#' || ch != '.')
                    //{
                    //    throw new ArgumentOutOfRangeException();
                    //}
                    new_row.Row.Add(new_seat);
                    c++;
                }
                Room.Add(new_row);
                r++;
                c = 0;
            };

            Console.WriteLine($"Read input file. {rf.LinesRead} lines read in.");

            return;
        }

        public void PrintRoom()
        {
            // print waiting room
            var n = 0;
            foreach (var row in Room)
            {
                Console.Write(String.Format("Row {0,2}: ", n));
                foreach (var s in row.Row)
                {
                    var d = CountSurroundings(s);
                    //Console.Write(String.Format("{0} {1},", s.State, d['L']));
                    Console.Write(String.Format("{0:-2}  ", s.State));
                }
                Console.WriteLine();
                n++;
            }
        }

        public void GenerateNext()
        {
            CopyRoomToSwap();

            char new_status;

            foreach (RowOfSeats r in Room)
            {
                foreach (Seat seat in r.Row)
                {
                    new_status = ApplyRules(seat);
                    seat.State = new_status;
                }
            };

            SwapOut();

            return;
        }

        public void SwapOut()
        {
            if (!(Room == null) && !(_nextGenRoom == null))
            {
                Room = _nextGenRoom;
                _nextGenRoom = null;
            }

            return;
        }

        private char ApplyRules(Seat seat)
        {
            char result;

            if (seat.State == '.')
            {
                //floor spot - no change
                return seat.State;
            }

            Dictionary<char, int> t = CountSurroundings(seat);

            if (seat.State == 'L' && t['#'] == 0)
            {
                // seat becomes occupied
                seat.State = '#';
                HasChanged = true;
            }
            else if (seat.State == '#' && t['#'] >= 4)
            {
                // seat becomes empty
                seat.State = 'L';
                HasChanged = true;
            }
            else
            {
                
            }

            return seat.State;
        }

        private Dictionary<char, int> CountSurroundings(Seat seat)
        {
            var result = new Dictionary<char, int>();
            result['L'] = 0;
            result['.'] = 0;
            result['#'] = 0;

            var seat_row = seat.SeatNumber.Item1;
            var seat_col = seat.SeatNumber.Item2;

            int[] rows = new int[] { -1, -1, -1, 0, 1, +1, +1, 0 };
            int[] cols = new int[] {-1, 0, +1, +1, +1, 0, -1, -1 };

            char stat;
            var r = 0;
            var c = 0;
            for (var i=0; i < rows.Length; i++)
            {
                // TODO: edge cases ??
                r = seat_row + rows[i];
                c = seat_col + cols[i];
                if ((r >= 0 && r < Room.Count-1) && (c >= 0 && c < Room[0].Row.Count - 1))
                {
                    stat = Room[r].Row[c].State;
                    result[stat] += 1;
                }
            }

            return result;
        }

        public int CountOfOccupiedSeats()
        {
            var n = 0;
            foreach (var row in Room)
            { 
                foreach (var s in row.Row)
                {
                    if (s.State == 'L')
                    {
                        n++;
                    }
                }
            }
            return n;
        }

        public void CopyRoomToSwap()
        {
            _nextGenRoom = new List<RowOfSeats>();
            RowOfSeats new_row;

            // build a waiting room...
            foreach (var r in Room)
            {
                new_row = new RowOfSeats();
                foreach (var seat in r.Row)
                {
                    var new_seat = new Seat(seat.SeatNumber.Item1, seat.SeatNumber.Item2);
                    new_seat.State = seat.State;
                    new_row.Row.Add(new_seat);
                }
                _nextGenRoom.Add(new_row);
            };

            return;
        }

    }
}

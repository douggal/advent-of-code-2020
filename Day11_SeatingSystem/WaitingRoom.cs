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
            HasChanged = false;

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
                    Console.Write(String.Format("{0:1}", s.State));
                }
                Console.WriteLine();
                n++;
            }
        }

        public void GenerateNext()
        {
            CopyRoomToSwap();

            char new_status;
            var r = 0;
            var c = 0;
            foreach (RowOfSeats row in Room)
            {
                foreach (Seat seat in row.Row)
                {
                    new_status = ApplyRules(seat);
                    _nextGenRoom[r].Row[c].State = new_status;
                    c++;
                }
                c = 0;
                r++;
            };

            HasChanged = CompareOldToNewRoom(_nextGenRoom);

            SwapOut();

            return;
        }

        private bool CompareOldToNewRoom(List<RowOfSeats> rm)
        {
            bool result = false;

            // build a waiting room...
            var r = 0;
            var c = 0;
            foreach (var row in Room)
            {
                foreach (var seat in row.Row)
                {
                    if (seat.State != rm[r].Row[c].State)
                    {
                        result = true;
                        break;
                    }
                    c++;
                }
                c = 0;
                r++;
            };

            return result;
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
            char result = seat.State;

            if (seat.State == '.')
            {
                //floor spot - no change
                return result; ;
            }

            Dictionary<char, int> t = CountSurroundings(seat);

            if (seat.State == 'L' && t['#'] == 0)
            {
                // seat becomes occupied
                result = '#';
            }
            else if (seat.State == '#' && t['#'] >= 4)
            {
                // seat becomes empty
                result = 'L';
            }
            else
            {
                
            }

            return result;
        }

        private Dictionary<char, int> CountSurroundings(Seat seat)
        {
            var result = new Dictionary<char, int>();
            result['L'] = 0;  // empty
            result['.'] = 0;  // floor
            result['#'] = 0;  // occupied

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
                if ((r >= 0 && r < Room.Count) && (c >= 0 && c < Room[0].Row.Count))
                {
                    stat = Room[r].Row[c].State;
                    result[stat] += 1;
                }
                // do nothing if one or both off the gird.  no wrapping around here. 
                //else if ((r < 0 || r >= Room.Count) && (c >= 0 && c < Room[0].Row.Count))
                //{
                //    // row is out of range but col (a row of seats) is Ok
                //    stat = Room[seat_row].Row[c].State;
                //    result[stat] += 1;
                //}
                //else if ((r >= 0 && r < Room.Count) && (c < 0 || c >= Room[0].Row.Count))
                //{
                //    // row is Ok, but col (row of seats) is out of range
                //    stat = Room[r].Row[seat_col].State;
                //    result[stat] += 1;
                //}
                else
                {
                    // do nothing both off the grid
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
                    if (s.State == '#')
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

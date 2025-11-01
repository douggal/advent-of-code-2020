using System.Collections.Generic;

namespace Day03_TobogganTrajectory
{
    public class CircularArrayOfChar
    {
        private List<char> _circularArray;
        public List<char> CircularArray
        {
            get { return _circularArray; }
            set { _circularArray = value; }
        }

        public CircularArrayOfChar() => _circularArray = new List<char>();

        public void Add(char c)
        {
            _circularArray.Add(c);
        }

        public char GetValueAt(int i)
        {
            // circular array or buffer - remainder of index points to desired element
            // array is 0 based and the count has actual count of values
            // so no need for checks or subtracting to account for edge cases
            var idx = i % _circularArray.Count;
            return _circularArray[idx];
        }

        public int CountOfItems() { return _circularArray.Count; }

    }
}
using System;

namespace Day10_AdapterArray
{
    /// <summary>
    /// An Accumulator - instance of which maintains a running average of values
    /// added one at a time.  Based on Sedgewick/Wayne Algorthms 4th ed.
    /// </summary>
    public class Accumulator
    {
        private double _total;
        private int N;

        public double Total
        {
            get { return _total; }
        }

        public Accumulator()
        {
            N = 0;
            _total = 0d;
        }

        public void AddDataValue(double val)
        {
            N++;
            _total += val;
        }

        public double Mean()
        {
            return _total / N;
        }

        public override string ToString()
        {
            return "Mean (" + N.ToString() + " values): " + String.Format("{0,5}", Mean());
        }
    }
}

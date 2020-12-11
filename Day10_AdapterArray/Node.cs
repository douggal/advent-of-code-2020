using System;
using System.Collections.Generic;
using System.Text;

namespace Day10_AdapterArray
{
    public class Node
    {

        public bool DeadEnd { get; set; }

        public bool EndOfChain { get; set; }

        public int ConnectionCount { get; set; }

        public double TotalConnectionCount { get; set; }

        public int Index { get; set; }

        public int Value { get; set; }

        public Node(int i, int v)
        {
            ConnectionCount = 0;
            TotalConnectionCount = 0;
            Index = i;
            Value = v;
            DeadEnd = false;
        }


    }
}

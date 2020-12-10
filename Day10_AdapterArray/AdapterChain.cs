using System;
using System.Collections.Generic;
using System.Text;

namespace Day10_AdapterArray
{
    public class AdapterChain
    {

        public List<int> Chain { get; set; }

        public bool Complete { get; set; }

        public int ChainCount { get { return Chain.Count; } }

        public AdapterChain()
        {
            Complete = false;
            Chain = new List<int>();
        }

    }
}

using System.Collections.Generic;

namespace Day03_TobogganTrajectory
{
    public class TallyOfResults
    {

        // to validate program and debug it I wanted to pass back all the stats
        // slope is down 1 so total of tree + open space hits should be 
        // total # rows in map - 1 for first row which can never have a tree hit or a miss
        public int TreeHits { get; set; }
        public int OpenSpaceHits { get; set; }
        public int ReachRight { get; set; }
    }
}

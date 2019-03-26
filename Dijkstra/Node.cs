using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class Node
    {
        public Point Value { get; set; } // Any type/value, the actual value of a node
        public double Distance { get; set; } // Possibly double, Relevant
        public bool Visited { get; set; } // Not neccesarry
        public Node Prev { get; set; }
    }
}

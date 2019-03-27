using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public class Node
    {
        public Point Value { get; set; } // Any type/value, the actual value of a node
        public double G { get; set; } // Distance, see Dijkstra
        public double H { get; set; } // Heuristic Value
        public double F { // Sum of heuristic value and distance
            get
            {
                if (G == double.MaxValue || H == double.MaxValue)
                    return double.MaxValue;
                else
                    return G + H;
            }
        }
        public Node Prev { get; set; }
    }
}

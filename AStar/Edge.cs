using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    public class Edge
    {
        public Point Left { get; set; }
        public Point Right { get; set; }
        public double Distance { get; set; }
    }
}

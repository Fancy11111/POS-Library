using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    // The interface INode
    // Defines one function "getDistance" which returns a double
    public interface INode
    {
        double getDistance();
    }

    // A class which implements the INode interface
    // Implements the "getDistance" method defined in the INode interface
    // Created by the DijkstraNodeFactory
    public class DijkstraNode : INode
    {
        public double Distance { get; set; }
        public double getDistance()
        {
            return Distance;
        }
    }

    // A class which implements the INode interface
    // Implements the "getDistance" method defined in the INode interface
    // Created by the AStarNodeFactory
    public class AStarNode : INode
    {
        public double H { get; set; }
        public double G { get; set; }
        public double getDistance()
        {
            return H + G;
        }
    }
}

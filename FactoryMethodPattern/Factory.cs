using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public enum NodeTypes
    {
        Dijkstra, AStar
    }
    public class Factory
    {
        // Factory Method
        // Creates a different concrete INode depending on the NodeType given as a parameter
        public static INode GetNode(NodeTypes type)
        {
            if(type == NodeTypes.Dijkstra)
            {
                return new DijkstraNode();
            }
            else if(type == NodeTypes.AStar)
            {
                return new AStarNode();
            }
            throw new NotSupportedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Example
    {
        static void main()
        {
            var algorithm = "dijkstra";
            INodeFactory factory;
            if(algorithm == "dijkstra")
            {
                factory = new DijkstraNodeFactory();
            } else
            {
                factory = new AStarNodeFactory();
            }

            INode node = factory.createNode();
            Console.WriteLine(node.getDistance());
        }
    }
}

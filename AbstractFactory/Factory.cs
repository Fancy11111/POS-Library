using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    // The Abstract Factory Interface
    // Defines one method "createNode" which returns an object that implements the INode interface
    public interface INodeFactory
    {
        INode createNode();
    }

    // A concrete Factory
    // Returns an AStarNode object
    public class AStarNodeFactory : INodeFactory
    {
        public INode createNode()
        {
            return new AStarNode();
        }
    }

    // A concrete Factory
    // Returns a DijkstraNode object
    public class DijkstraNodeFactory : INodeFactory
    {
        public INode createNode()
        {
            return new DijkstraNode();
        }
    }
}

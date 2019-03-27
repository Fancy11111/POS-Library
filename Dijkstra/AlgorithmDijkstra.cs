using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Djikstra
{
    public class AlgorithmDijkstra
    {
        private List<Node> nodes; // "Graph"
        
        private void Initialize(List<Point> values, Point start)
        {
            nodes = new List<Node>();
            Node n;
            foreach(var v in values)
            {
                n = new Node
                {
                    Value = v,
                    Prev = null,
                    Visited = false
                };

                if(n.Value == start)
                {
                    n.Distance = 0; // Distance of start node = 0
                } else
                {
                    n.Distance = double.MaxValue;
                }

                nodes.Add(n); // Add to graph
            }
        }

        // For a graph with all nodes connected to each other
        // For example points on a map
        public Node DjikstraForVectorDistance(List<Point> values, Point start, Point end)
        {
            Initialize(values, start);
            Node curr = null;
            while(nodes.Count != 0)
            {
                curr = nodes.Where(n => !n.Visited).OrderBy(n => n.Distance).FirstOrDefault();
                if (curr == null) // All nodes visited, end not found
                    break;
                curr.Visited = true;
                //nodes.Remove(curr);
                if(curr.Value == end) // end found
                    break;
                var neighbors = nodes.Select(n =>
                    new { EdgeDistance = Math.Sqrt(Math.Pow((curr.Value.X - n.Value.X), 2) + Math.Pow((curr.Value.Y - n.Value.Y), 2)), // EdgeDistance = Vector Distance
                        Node = n }
                );

                foreach(var dynamicN in neighbors)
                {
                    if(dynamicN != null)
                    {
                        var neighborDist = curr.Distance + dynamicN.EdgeDistance;
                        if(dynamicN.Node.Distance > neighborDist) // If currNode Distance + EdgeDistance is smaller than the distance of the neighbor
                        {
                            dynamicN.Node.Distance = neighborDist; // Set distance to currNode Distance + EdgeDistance
                            dynamicN.Node.Prev = curr; // Set Prev of neighbor to currNode
                        }
                    }
                }
            }
            return curr;
        }

        // For graphs where not all nodes are connected
        public Node DjikstraForEdges(List<Point> values, List<Edge> edges,  Point start, Point end, bool twoWay)
        {
            Initialize(values, start);
            Node curr = null;
            IEnumerable<dynamic> neighbors = null;
            while (nodes.Count(n => !n.Visited) != 0)
            {
                curr = nodes.Where(n => !n.Visited).OrderBy(n => n.Distance).FirstOrDefault();
                if (curr == null) // All nodes visited, end not found
                    break;
                curr.Visited = true;
                //nodes.Remove(curr);
                if (curr.Value == end) // end found
                    break;

                if (twoWay) // Edges can be traversed both ways
                {
                    neighbors = edges
                            .Where(e => e.Left.ID == curr.Value.ID) // Where Point ID from curr = Point ID for "left" part of the edge
                            .Select(e => new { EdgeDistance = e.Distance, // EdgeDistance is the distance defined in the edge
                                Node = nodes.First(n => n.Value.ID == e.Right.ID) }) // Node is the right Node of the edge
                        .Concat(edges 
                            .Where(e => e.Right.ID == curr.Value.ID) // Where Point ID from curr = Point ID for "right" part of the edge
                            .Select(e => new { EdgeDistance = e.Distance, // EdgeDistance is the distance defined in the edge
                                Node = nodes.First(n => n.Value.ID == e.Left.ID) // Node is the left Node of the edge
                            }));
                }
                else // Edges can only be traversed left to right
                {
                    neighbors = edges
                        .Where(e => e.Left.ID == curr.Value.ID) // Where Point ID from curr = Point ID for "left" part of the edge
                        .Select(e => new { EdgeDistance = e.Distance, // EdgeDistance is the distance defined in the edge
                            Node = nodes.First(n => n.Value.ID == e.Right.ID) }); // Node is the right Node of the edge
                }

                if(neighbors != null)
                {
                    foreach (var dynamicN in neighbors)
                    {
                        if (dynamicN != null)
                        {
                            var neighborDist = curr.Distance + dynamicN.EdgeDistance;
                            if (dynamicN.Node.Distance > neighborDist) // If currNode Distance + EdgeDistance is smaller than the distance of the neighbor
                            {
                                dynamicN.Node.Distance = neighborDist; // Set distance to currNode Distance + EdgeDistance
                                dynamicN.Node.Prev = curr; // Set Prev of neighbor to currNode
                            }
                        }
                    }
                }
            }
            return curr;
        }

        public List<Node> createShortestPath(Node n)
        {
            List<Node> path = new List<Node>();
            while (n != null) {
                path.Insert(0, n);
                n = n.Prev;
            }
            return path;
        }

        public void NearestNeighbor(List<Point> values, Node start)
        {
            Initialize(values, start.Value);
            List<Node> path = new List<Node>();
            path.Add(start);
            var curr = start;
            while (nodes.Count(n => !n.Visited) != 0)
            {
                curr = nodes.Where(n => !n.Visited).OrderBy(n =>
                    Math.Sqrt(Math.Pow((curr.Value.X - n.Value.X), 2) + Math.Pow((curr.Value.Y - n.Value.Y), 2))
                ).First();

                path.Insert(0, start);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Algorithm
    {
        public List<Node> nodes;
        public Point end;

        public void AStar(List<Point> values, List<Edge> edges, Point start, Point _end){
            Node curr;
            this.end = _end;
            Initialize(values, start, out curr);
            List<Node> openSet = new List<Node>();
            List<Node> closedSet = new List<Node>();
            openSet.Add(curr);

            while(openSet.Count != 0)
            {
                curr = openSet.OrderBy(n => n.F).First(); // Open node with smallest H + G
                if (curr.Value.ID == end.ID)
                    break;

                openSet.Remove(curr); // Basically set visited
                closedSet.Add(curr);

                var neighbors = edges
                            .Where(e => e.Left.ID == curr.Value.ID) // Where Point ID from curr = Point ID for "left" part of the edge
                            .Select(e => new {
                                EdgeDistance = e.Distance, // EdgeDistance is the distance defined in the edge
                                Node = nodes.First(n => n.Value.ID == e.Right.ID)
                            }) // Node is the right Node of the edge
                        .Concat(edges
                            .Where(e => e.Right.ID == curr.Value.ID) // Where Point ID from curr = Point ID for "right" part of the edge
                            .Select(e => new {
                                EdgeDistance = e.Distance, // EdgeDistance is the distance defined in the edge
                                Node = nodes.First(n => n.Value.ID == e.Left.ID) // Node is the left Node of the edge
                            }));

                foreach (var dynamicN in neighbors)
                {
                    if(dynamicN != null)
                    {
                        if (!closedSet.Contains(dynamicN.Node)) // Optimal path for node not already found
                        {
                            var neighborDist = curr.G + dynamicN.EdgeDistance; // G-Distance for neighbor
                            if (!openSet.Contains(dynamicN.Node)) // Node never seen before
                                openSet.Add(dynamicN.Node); // Add to open set
                            if(neighborDist < dynamicN.Node.G) // New Distance is better than the old g-distance
                            {
                                dynamicN.Node.Prev = curr; // Set curr as Prev of neighbor
                                dynamicN.Node.G = neighborDist; // set new G-Distance
                            }
                        }
                    }
                }
            }
        }

        private void Initialize(List<Point> values, Point start, out Node curr)
        {
            nodes = new List<Node>();
            Node n;
            curr = null;
            foreach (var v in values)
            {
                n = new Node
                {
                    Value = v,
                    Prev = null
                };

                if (n.Value == start)
                {
                    n.G = 0; // Distance of start node = 0
                    curr = n;
                }
                else
                {
                    n.G = double.MaxValue;
                }
                // If the heuristic function is consistent
                // Otherwise you have to recalculate when you calculate g-distance
                // and you set H to double.MaxValue
                n.H = HeuristicFunction(n);

                nodes.Add(n); // Add to nodelist
            }
        }

        // A funtion that calculates a cost based on a criteria
        // In this case, the vector distance
        double HeuristicFunction(Node n)
        {
            return Math.Sqrt(Math.Pow(n.Value.X - end.X, 2) + Math.Pow(n.Value.Y - end.Y, 2));
        }
    }
}

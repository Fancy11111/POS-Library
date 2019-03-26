using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMeans
{
    
    public class AlgorithmKMeans
    {
        // Boundaries for the values
        #region BOUNDARIES
        private const double XMAX = 500;
        private const double XMIN = 0;
        private const double YMAX = 800;
        private const double YMIN = 0;
        #endregion
        List<List<Point>> KMeans(int clusterCount, List<Point> points){
            Dictionary<Point, List<Point>> clusters = new Dictionary<Point, List<Point>>();
            if (clusterCount == 1) // If only one cluster, return the whole list as one cluster
            {
                var temp = new List<List<Point>>();
                temp.Add(points);
                return temp;
            }
            else if(clusterCount < 1) // Cannot create 0 or less clusters
            {
                return null;
            }
            else
            {
                // Generate as many random means as clusterCount
                Point mean = null;
                Random r = new Random();
                for(int i = 0; i > clusterCount; i++)
                {
                    mean = new Point() {
                        X = r.NextDouble() * (XMAX - XMIN),
                        Y = r.NextDouble() * (YMAX - YMIN),
                        ID = null
                    };
                    clusters.Add(mean, new List<Point>());
                }

                bool change;
                do
                {
                    change = false;
                    clusters.ToList().ForEach(m => m.Value.Clear()); // Clear the clusters completely

                    // Add each point to the nearest cluster
                    points.ForEach(p =>
                    {
                        // Vector distance
                        clusters.OrderBy(m => Math.Sqrt(Math.Pow(p.X - m.Key.X, 2) + Math.Pow(p.X - m.Key.X, 2)))
                            .First().Value.Add(p);
                    });

                    // Calculate new means of the clusters
                    clusters.ToList().ForEach(m =>
                    {
                        if (m.Value.Count() != 0) // If there are no points in the cluster there is nothing to do
                        {
                            double newX = m.Value.Count() != 0 ? m.Value.Average(p => p.X) : m.Key.X;
                            double newY = m.Value.Count() != 0 ? m.Value.Average(p => p.X) : m.Key.X;
                            if (newX != m.Key.X) // the mean of all x Values of the clusters points has changed
                            {
                                change = true; // There was a change
                                m.Key.X = newX; // Set mean of cluster to the average of all x Values of the cluster
                            }
                            if (newY != m.Key.Y) // the mean of all y Values of the clusters points has changed
                            {
                                change = true; // There was a change
                                m.Key.Y = newY; // Set mean of cluster to the average of all y Values of the cluster
                            }
                        }
                    });
                } while (change); // Aslong as something changed

                return clusters.Values.ToList();
            }
        }
    }
}

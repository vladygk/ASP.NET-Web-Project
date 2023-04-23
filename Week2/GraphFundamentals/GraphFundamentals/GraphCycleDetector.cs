using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFundamentals
{
    public class GraphCycleDetector
    {
        public static bool DetectCycle( List<List<int>> graph)
        {HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            int node = 0; // start node 
            queue.Enqueue(node);
            visited.Add(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                
                foreach (var child in graph[current])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}

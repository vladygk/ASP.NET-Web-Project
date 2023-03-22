using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFundamentals
{
    public class HamiltonianPath
    {
        public static bool IsHamiltonian(Dictionary<string, List<string>> graph , string startNode)
        {
            bool isHamilt = false;
            
            HashSet<string> visited = new HashSet<string>();

            DFS(startNode, graph, graph.Count, visited, 0, ref isHamilt);

            return isHamilt;
        }
     



        public static void DFS(string node, Dictionary<string, List<string>> graph, int numberOfVertices, HashSet<string> visited, int counter, ref bool isHamilt)
        {
            counter++;
            if (counter == numberOfVertices)
            {
                isHamilt = true;
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    DFS(child, graph, numberOfVertices, visited, counter, ref isHamilt);
                    counter--;

                }
            }
            Console.WriteLine(node);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphFundamentals
{
    public class CalculateValueOfFieldsFunction
    {
        public static Dictionary<int,int> CalculateFields(List<List<int>> graph)
        {
            if (GraphCycleDetector.DetectCycle(graph))
            {
                throw new ArgumentException("Circular dependency!");

            }
            Dictionary<int, int> allCalculatedFields = new Dictionary<int, int>();

            // List<List<int>> fieldsWithDependencies = graph.Where(x=>x.Count > 0).ToList();  

            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].Count > 0)
                {
                    allCalculatedFields.Add(i, graph[i].Sum());

                }
                else
                {
                    allCalculatedFields.Add(i, i);
                }
            }

            return allCalculatedFields;
        }
    }
}

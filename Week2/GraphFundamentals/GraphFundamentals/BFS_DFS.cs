namespace GraphFundamentals;

public class BFS_DFS
{


    public static void BFS(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
    {
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(node);
        visited.Add(node);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine(current);
            foreach (var child in graph[current])
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
        }

    }

    public static void DFS(int node, Dictionary<int, List<int>> graph, HashSet<int> visited)
    {

        visited.Add(node);

        foreach (var child in graph[node])
        {
            if (!visited.Contains(child))
            {
                visited.Add(child);
                DFS(child, graph, visited);

            }
        }
        Console.WriteLine(node);
    }


}
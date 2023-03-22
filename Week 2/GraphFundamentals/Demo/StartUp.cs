namespace Demo;
using GraphFundamentals;

internal class StartUp
{
    static void Main()
    {
         HashSet<int> visited = new HashSet<int>();
         Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        graph.Add(1, new List<int>() { 2});
        graph.Add(2, new List<int>() { 3 });
        graph.Add(3, new List<int>() { 4});
        graph.Add(4, new List<int>());
        // BFS_DFS.BFS(1, graph, visited);
        // BFS_DFS.DFS(1, graph, visited);
        List<List<int>> graphC = new List< List<int>>();
        graphC.Add(new List<int>() { 1 }); //0
        graphC.Add(new List<int>() { 2 });
        graphC.Add(new List<int>() { 3 });
        graphC.Add(new List<int>());

        bool existCycle =   GraphCycleDetector.DetectCycle(graphC);
        Console.WriteLine(existCycle);
    }
}
using System.Security.Cryptography.X509Certificates;
using OopFundamentals;

namespace Demo
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var result = Solution(2000);
            foreach (var line in result)
            {
                Console.WriteLine(String.Join(" ",line));
            }
        }

        static IList<IList<int>> Solution(int n)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            for (int i = 0; i < n; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < i + 1; j++)
                {
                    line.Add(GeneratePascal(i, j, memo));
                }

                result.Add(line);
            }
            return result;
        }

        static int GeneratePascal(int x, int y, Dictionary<(int, int), int> memo)
        {
            if (x == 0 || x == y || y == 0)
            {


                return 1;
            }

            if (memo.ContainsKey((x, y)))
            {
                return memo[(x, y)];
            }
            int toAdd = GeneratePascal(x - 1, y - 1, memo) + GeneratePascal(x - 1, y, memo);

            memo.Add((x, y), toAdd);
            return toAdd;
        }

    }
}
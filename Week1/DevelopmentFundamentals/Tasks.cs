using System;
using System.Collections.Generic;
using System.Linq;


namespace dotnetcore
{
    class Tasks
    {
        static int[] OrderByBits(int[] input) => input.OrderByDescending(x => CalculateSumOfBits(x)).ToArray();



        static int CalculateSumOfBits(int n)
        {
            int[] numberInBinary = new int[1000];
            for (int i = 0; n > 0; i++)
            {
                numberInBinary[i] = n % 2;
                n = n / 2;
            }
            return numberInBinary.Sum();
        }

        static int GenerateFibonacci(int n, List<int> seq, Dictionary<int, int> memo)
        {

            if (n == 1 || n == 2)
            {
                return 1;
            }
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }


            int value = GenerateFibonacci(n - 1, seq, memo) + GenerateFibonacci(n - 2, seq, memo);
            seq.Add(value);
            if (!memo.ContainsKey(n))
            {
                memo.Add(n, value);
            }
            return value;

        }

        static bool CheckIsBorderFibonacci(int[][] matrix, List<int> fib)
        {
            List<int> border = GetBorder(matrix);
            // Console.WriteLine(String.Join(" ",border));
            if (!fib.Contains(border[0]))
            {
                return false;
            }

            int startIndex = fib.IndexOf(border[0]);
            for (int i = startIndex; i < border.Count; i++)
            {
                if (fib[i] != border[i])
                {
                    return false;
                }
            }
            return true;
        }



        static List<int> GetBorder(int[][] matrix)
        {
            List<int> border = new List<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                border.Add(matrix[0][i]);
            }

            for (int i = 1; i < matrix.Length - 1; i++)
            {
                border.Add(matrix[i][matrix.Length - 1]);
            }

            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                border.Add(matrix[matrix.Length - 1][i]);
            }

            for (int i = matrix.Length - 2; i >= 1; i--)
            {
                border.Add(matrix[i][0]);
            }

            return border;
        }
        static void Main(string[] args)
        {
            Dictionary<int, int> memo = new Dictionary<int, int>(); //to store values for momoization

            List<int> seq = new List<int>() { 1, 1 }; //the fibonacci sequence

            GenerateFibonacci(30, seq, memo);

            //Input
            int[][] matrix = new int[2][];

            //Console.WriteLine(String.Join(" ", seq));
            matrix[0] = new int[] { 1, 1 };
            matrix[1] = new int[] { 3, 2 };

            //Console.WriteLine(CheckIsBorderFibonacci(matrix, seq));

            int[] ordered = OrderByBits(new int[] { 8, 13, 1 });
            Console.WriteLine(String.Join(" ",ordered));
        }
    }
}

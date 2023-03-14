using System;

namespace SmallTasksCS
{
    public class SmallTasksFunctions
    {
        internal static void Main(string[] args)
        {


        }

        public static bool isOdd(int n) => n % 2 != 0;

        public static bool isPrime(int n)
        {
            if (n <= 1)
            {
                return false;
            }
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int Min(int[] arr) => arr.Min();

        public static int KthMin(int k, int[] array)
        {
            if (k > array.Length)
            {
                throw new ArgumentException();
            }
            for (int i = 0; i < k - 1; i++)
            {
                int min = array.Min();
                array[Array.IndexOf(array, min)] = int.MaxValue;
            }
            return array.Min();
        }

        public static int GetOddOccurrence(int[] array)
        {
            int oddOccurNum = array.FirstOrDefault(x => (array.Count(n => n == x) % 2 != 0));
            if (oddOccurNum == 0 && array.Count(x => x == 0) % 2 == 0)
            {
                throw new ArgumentException("No such number");
            }

            return oddOccurNum;
        }

        public static int GetAverage(int[] array) => array.Sum() / array.Length;

        public static long pow (int a, int b)
        {
            if (b == 0)
            {
                return 0;
            }

            if(b == 1)
            {
                return a;
            }

            if (b < 0)
            {
                a = 1 / a;
                b = -b;
            }
            return a * pow(a, b - 1);
        }

    }
}
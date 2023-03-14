

using System.Text;

namespace SmallTasksCS
{
    public class SmallTasksFunctions
    {
        internal static void Main(string[] args)
        {
            int[] arr = { 6, 2, 2, 4 };
            EqualSumSides(arr);
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

        public static long GetSmallestMultiple(int N)
        {
            if (N < 1)
            {
                throw new ArgumentException();
            }
            List<int> input = new List<int>();
            for (int i = 1; i<= N; i++)
            {
                input.Add(i);
            }

            return input.Aggregate((S, val) => S * val / gcd(S, val));

        }

        public static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return gcd(b, a %b);
            }
        }

        public static long DoubleFac(int n)
        {
            if (n < 0)
            {
                throw new InvalidOperationException();
            }
            if(n == 0)
            {
                return 1;
            }
            long firstFac = 1;
            long secondFac = 1;
            for (int i = 1; i <= n; i++)
            {
                firstFac *= i;
            }
            for (int i = 1; i <= firstFac; i++)
            {
                secondFac *= i;
            }

            return secondFac;
        }

        public static long KthFac(int k,int n)
        { int total = 1;
            while (k-- > 0)
            {
                total = 1;
                if (n != 0)
                {

                    for (int i = 1; i <= n; i++)
                    {
                        total *= i;
                    }
                    n = total;
                   
                }
            }
            return total;
        }

        public static bool EqualSumSides(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;

                for (int j = 0; j <=i-1 ; j++)
                {
                    leftSum+= numbers[j];
                }

                int rightSum = 0;

                for (int j = i+1; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }

                if( leftSum== rightSum)
                {
                    return true;
                }
            }
            return false;
        }

        public static string Reverse(string argument) => new string(argument.ToCharArray().Reverse().ToArray());

        public static string ReverseEveryWord(string arg)
        {
            StringBuilder sb = new StringBuilder();
            string[] argsArr = arg.Split();

            for(int i = 0;i < argsArr.Length;i++)
            {
                sb.Append(Reverse(argsArr[i])+" ");
            }
            return sb.ToString().Trim();
        }
    }
}
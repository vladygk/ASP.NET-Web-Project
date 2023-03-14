namespace SmallTasksCS
{
    public class SmallTasksFunctions
    {
       internal static void Main(string[] args)
        {
            
        }

       public static  bool isOdd(int n) => n % 2 != 0;

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
            for (int i = 0; i < k-1; i++) {
                int min = array.Min();
                array[Array.IndexOf(array, min)] = int.MaxValue;
            }
            return array.Min();
        }
    }
}
using System.Numerics;

namespace Complexity_fundamentals
{
    public class ComplexityFundamentals
    {


        static void Main(string[] args)
        {
            double[] arr = new double[] { 13, 15, 14, 12, 10, 9 };
            Console.WriteLine(FindMissing(arr));


            Console.WriteLine(FindCubicRoot(-27));
        }

        // 1 3 4     2.5*4

        public static double FindMissing(double[] nums)
        {
            if (nums.Length <= 1)
            {
                throw new ArgumentException();
            }
            double min = nums.Min();
            double max = nums.Max();
            double sum = nums.Sum();

            double expectedSum = ((min + max) / 2) * (nums.Length + 1);

            return expectedSum - sum;
        }

        public static BigInteger FindCubicRoot(int x)
        {

            BigInteger start = 0;
            BigInteger end = x;

            while (true)
            {
                BigInteger middle = (end + start) /2;
                if (middle * middle * middle == x)
                {
                    return middle;
                }
                else if (middle * middle * middle < x)
                {
                    start = middle + 1;


                }
                else if (middle * middle * middle > x)
                {

                    end = middle - 1;
                }

            }
        }

    }
}
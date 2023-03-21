using System.Numerics;

namespace Complexity_fundamentals
{
    public class ComplexityFundamentals
    {


        static void Main(string[] args)
        {
            int[] arr = new int[] { 13, 15, 14, 12, 10, 9 };
            Console.WriteLine(FindMissing(arr));


            Console.WriteLine(FindCubicRoot(-27));
        }

        // 1 3 4     2.5*4

        public static int FindMissing(int[] nums)
        {
            if (nums.Length <= 1)
            {
                throw new ArgumentException();
            }
            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < min)
                {
                    min = nums[i];
                }

                if (nums[i] > max)
                {
                    max = nums[i];  
                }

                sum += nums[i];
            }

            int expectedSum = ((min + max) * (nums.Length + 1))/2;

            return expectedSum - sum;
        }

        public static int FindCubicRoot(int x)
        {

            int start = 0;
            int end = 1290;

            while (true)
            {
                int middle = (end + start) /2;
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
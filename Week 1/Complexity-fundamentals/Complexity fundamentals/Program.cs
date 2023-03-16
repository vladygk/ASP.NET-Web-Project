namespace Complexity_fundamentals
{
    internal class Program
    {

        static void Swap(int[] arr, int first, int second)
        {
            int buff = arr[first];
            arr[first] = arr[second];
            arr[second] = buff;
        }
        static int[] MergeSort(int[] arr)
        {

            if (arr.Length == 1)
            {
                return arr;
            }

            int middleIdx = arr.Length / 2;
            int[] firstHalf = arr.Take(middleIdx).ToArray();
            int[] secondHalf = arr.Skip(middleIdx).ToArray();

            return MergeArrays(MergeSort(firstHalf), MergeSort(secondHalf));

        }

        private static int[] MergeArrays(int[] left, int[] right)
        {
            int[] sorted = new int[left.Length + right.Length];

            int leftIdx = 0, rightIdx = 0, sortedIdx = 0;


            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    sorted[sortedIdx++] = left[leftIdx++];
                }
                else
                {
                    sorted[sortedIdx++] = right[rightIdx++];
                }

            }

            while (leftIdx < left.Length)
            {
                sorted[sortedIdx++] = left[leftIdx++];

            }

            while (rightIdx < right.Length)
            {
                sorted[sortedIdx++] = right[rightIdx++];
            }

            return sorted;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 13, 15, 14, 12, 10, 9 };
            //Console.WriteLine(FindMissing(arr));


            Console.WriteLine(FindCubicRoot(27));
        }

       

        static int FindMissing(int[] nums)
        {
            var sorted = MergeSort(nums);


            for (int i = 0; i < nums.Length-1; i++)
            {
                if (sorted[i + 1] - sorted[i] > 1)
                {
                    return sorted[i] + 1;
                }
            }
            return -1;
        }

        static double FindCubicRoot(int x)
        {
            return  Math.Round(Math.Pow(x, 1.0 / 3.0));
        }
    }
}
namespace Demo
{
    using TreesFundamentals;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            TreeNode leftChild = new TreeNode(2, null, null);
            TreeNode rigthChild = new TreeNode(3, null, null);
            TreeNode parent = new TreeNode(1, leftChild, rigthChild);



            //TreeFunctions.PreOrder(parent);
            //TreeFunctions.PostOrder(parent);
            //TreeFunctions.InOrder(parent);
            List<int> list1 = new List<int>() { 1, 3, 5 };
            List<int> list2 = new List<int>() { 2,4,6 };
            List<int> list3 = new List<int>() { 7 };

            List<List<int>> listOfLists = new List<List<int>>()
            {
                list1, list2 , list3
            };
            Console.WriteLine(String.Join("  ", TreeFunctions.MergeSortedLists(listOfLists)));
           
        }
    }
}
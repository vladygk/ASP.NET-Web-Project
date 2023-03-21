namespace Demo
{
    using TreesFundamentals;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            TreeNode node9 = new TreeNode(76, null, null);
            TreeNode node8 = new TreeNode(61, null, null);
            TreeNode node7 = new TreeNode(35, null, null);

            TreeNode node6 = new TreeNode(69, node8, node9);
            TreeNode node5 = new TreeNode(38, node7, null);
            TreeNode node4 = new TreeNode(24, null, null);

            TreeNode node3 = new TreeNode(52, node5, node6);
            TreeNode node2 = new TreeNode(11, null, node4);
            TreeNode node1 = new TreeNode(25, node2, node3);

            List<TreeNode> list = new List<TreeNode>();
            TreeFunctions.PreOrder(node1, list);

            Console.WriteLine(String.Join(" ",list.Select(x=>x.Value)));
        }
    }
}
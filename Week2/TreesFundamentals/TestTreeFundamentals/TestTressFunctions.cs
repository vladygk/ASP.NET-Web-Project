namespace TestTreeFundamentals
{
    using System.Xml.Linq;
    using TreesFundamentals;
    [TestClass]
    public class TestTreeFunctions
    {
        [TestMethod]
        public void TestPreOrderTraversal()
        {
            //Arrange
            TreeNode node9 = new TreeNode(76, null, null);
            TreeNode node8 = new TreeNode(61, null, null);
            TreeNode node7 = new TreeNode(35, null, null);

            TreeNode node6 = new TreeNode(69, node8, node9);
            TreeNode node5 = new TreeNode(38, node7, null);
            TreeNode node4 = new TreeNode(24, null, null);

            TreeNode node3 = new TreeNode(52, node5, node6);
            TreeNode node2 = new TreeNode(11, null, node4);
            TreeNode node1 = new TreeNode(25, node2, node3);

            List<TreeNode> expected = new List<TreeNode>()
            {
                 node1,node2,node4,node3,node5,node7,node6,node8,node9
            };
            //Act
            List<TreeNode> actual = new List<TreeNode>();
            TreeFunctions.PreOrder(node1, actual);
            //Assert
            
            CollectionAssert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestPostOrderTraversal()
        {
            //Arrange
            TreeNode leftChild = new TreeNode(2, null, null);
            TreeNode rigthChild = new TreeNode(3, null, null);
            TreeNode parent = new TreeNode(1, leftChild, rigthChild);
            List<TreeNode> expected = new List<TreeNode>()
            {
                 leftChild, rigthChild,parent
            };
            //Act
            List<TreeNode> actual = new List<TreeNode>();
            TreeFunctions.PostOrder(parent, actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);


        }
        [TestMethod]
        public void TestInOrderTraversal()
        {

            //Arrange
            TreeNode leftChild = new TreeNode(2, null, null);
            TreeNode rigthChild = new TreeNode(3, null, null);
            TreeNode parent = new TreeNode(1, leftChild, rigthChild);
            List<TreeNode> expected = new List<TreeNode>()
            {
                 leftChild, parent,rigthChild
            };
            //Act
            List<TreeNode> actual = new List<TreeNode>();
            TreeFunctions.InOrder(parent, actual);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetHeight()
        {
            //Arrange
            TreeNode node4 = new TreeNode(2, null, null);
            TreeNode node5 = new TreeNode(2, null, null);
            TreeNode node3 = new TreeNode(2, node4, node5);
            TreeNode node2 = new TreeNode(3, null, null);
            TreeNode node1 = new TreeNode(1, node2, node3);
            int expectedHeight = 2;

            //Act
            int height = -1;
            int maxHeight = 0;
            TreeFunctions.GetHeight(node1, ref height, ref maxHeight);
            //Assert
            Assert.AreEqual(expectedHeight, maxHeight);
        }

        [TestMethod]
        public void TestCheckIfThreeIsBinarySearchWithBinarySearchTree()
        {
            //Arrange
            TreeNode node3 = new TreeNode(4, null, null);
            TreeNode node2 = new TreeNode(1, null, null);
            TreeNode node1 = new TreeNode(3, node2, node3);

            //Act
            bool isBinarySearch = TreeFunctions.CheckIfThreeIsBinarySearch(node1);

            //Assert
            Assert.IsTrue(isBinarySearch);
        }

        [TestMethod]
        public void TestCheckIfThreeIsBinarySearchWithNonBinarySearchTree()
        {
            //Arrange
            TreeNode node3 = new TreeNode(4, null, null);
            TreeNode node2 = new TreeNode(1, null, null);
            TreeNode node1 = new TreeNode(10, node2, node3);

            //Act
            bool isBinarySearch = TreeFunctions.CheckIfThreeIsBinarySearch(node1);

            //Assert
            Assert.IsFalse(isBinarySearch);
        }

        [TestMethod]
        public void TestGetKSmallestElementInBFS()
        {
            //Arrange
            TreeNode node4 = new TreeNode(12, null, null);
            TreeNode node5 = new TreeNode(20, null, null);
            TreeNode node3 = new TreeNode(15, node4, node5);
            TreeNode node2 = new TreeNode(5, null, null);
            TreeNode node1 = new TreeNode(10, node2, node3);

            int k = 2;
            int expected = 10;

            //Act
            int actual = TreeFunctions.GetKSmallestElementInBFS(node1, k);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMergeSortedLists()
        {
            //Arrange
            List<int> list1 = new List<int>() { 1, 3, 5 };
            List<int> list2 = new List<int>() { 2, 4, 6 };
            List<int> list3 = new List<int>() { 7 };

            List<List<int>> listOfLists = new List<List<int>>()
            {
                list1, list2 , list3
            };
            List<int> expected = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            //Act
            List<int> actual = TreeFunctions.MergeSortedLists(listOfLists);

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHeapSort()
        {
            //Arrange
            List<int> input = new List<int>() { 5, 2, 7, 3 };
            List<int> expected = new List<int> { 2,3,5,7 };
            //Act
             TreeFunctions.HeapSort(input);

            //Assert
            CollectionAssert.AreEqual(expected, input);
        }
    }
}
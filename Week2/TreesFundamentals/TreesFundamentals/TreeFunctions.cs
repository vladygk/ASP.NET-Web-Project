

namespace TreesFundamentals
{
    public class TreeFunctions
    {
        public static void PreOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
            {
                return;
            }

            nodes.Add(node);
            PreOrder(node.LeftChild, nodes);
            PreOrder(node.RightChild, nodes);
        }

        public static void PostOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.LeftChild, nodes);
            PostOrder(node.RightChild, nodes);
            nodes.Add(node);
        }

        public static void InOrder(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.LeftChild, nodes);
            nodes.Add(node);
            InOrder(node.RightChild, nodes);
        }

        public static void GetHeight(TreeNode root, ref int height, ref int maxHeight)
        {
            if (root == null)
            {

                if (height > maxHeight)
                {
                    maxHeight = height;
                }

                return;
            }
            height++;
            GetHeight(root.LeftChild, ref height, ref maxHeight);

            GetHeight(root.RightChild, ref height, ref maxHeight);
            height--;
        }

        public static bool CheckIfThreeIsBinarySearch(TreeNode root)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                TreeNode currentNode = nodes.Dequeue();

                if (currentNode.LeftChild != null)
                {
                    nodes.Enqueue(currentNode.LeftChild);
                    if (currentNode.Value < currentNode.LeftChild.Value)
                    {
                        return false;
                    }
                }
                if (currentNode.RightChild != null)
                {
                    nodes.Enqueue(currentNode.RightChild);
                    if (currentNode.Value > currentNode.RightChild.Value)
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public static int GetKSmallestElementInBFS(TreeNode root, int k)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            List<int> listOfNodeValues = new List<int>();
            while (nodes.Count > 0)
            {
                TreeNode currentNode = nodes.Dequeue();
                listOfNodeValues.Add(currentNode.Value);
                if (currentNode.LeftChild != null)
                {
                    nodes.Enqueue(currentNode.LeftChild);

                }
                if (currentNode.RightChild != null)
                {
                    nodes.Enqueue(currentNode.RightChild);

                }
            }
            return GetKSmallestElement(listOfNodeValues, k);
        }
        private static int GetKSmallestElement(List<int> elements, int k)
        {
            return elements.OrderBy(x => x).ToList()[k - 1];
        }

        public static List<int> MergeSortedLists(List<List<int>> listOfSortedLists)
        {


            PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
            for (int i = 0; i < listOfSortedLists.Count; i++)
            {
                for (int j = 0; j < listOfSortedLists[i].Count; j++)
                {
                    queue.Enqueue(listOfSortedLists[i][j], listOfSortedLists[i][j]);
                }
            }
            List<int> merged = new List<int>();
            while (queue.Count > 0)
            {
                merged.Add(queue.Dequeue());
            }
            return merged;
        }

        public static void HeapSort(List<int> input)
        {
         
        
            for (int i = input.Count / 2; i >= 0; i--)
            {
                heapify(input, input.Count - 1, i);
            }
            for (int i = input.Count - 1; i >= 0; i--)
            {
                //swap last element of the max-heap with the first element

                (input[i], input[0]) = (input[0], input[i]);
                

                //exclude the last element from the heap and rebuild the heap 
                heapify(input, i - 1, 0);
            }

        }
        static void heapify(List<int> Array, int size, int index)
        {
            int max = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            //if the left element is greater than root
            if (left <= size && Array[left] > Array[max])
            {
                max = left;
            }

            //if the right element is greater than root
            if (right <= size && Array[right] > Array[max])
            {
                max = right;
            }

            //if the max is not i
            if (max != index)
            {
                int temp = Array[index];
                Array[index] = Array[max];
                Array[max] = temp;
                
                heapify(Array, size, max);
            }
        }
    }
}
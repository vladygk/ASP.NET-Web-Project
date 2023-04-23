using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesFundamentals
{
    public class TreeNode
    {
        public TreeNode(int value, TreeNode leftChild, TreeNode rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
        

        public int  Value{ get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }

    }
}

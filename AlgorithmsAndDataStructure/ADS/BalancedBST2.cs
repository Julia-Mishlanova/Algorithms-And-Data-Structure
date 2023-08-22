using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;
        public int Level;

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }


    public class BalancedBST2
    {
        public BSTNode Root;
        public BalancedBST2()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            Array.Sort(a);
            var node = StartGenerateTree(a, 0, a.Length - 1, 1, null);
            Root = node;
        }

        private BSTNode StartGenerateTree(int[] a, int start, int end, int level, BSTNode parent)
        {
            if (start > end)
            {
                return null;
            }

            var mid = end + (start - end) / 2;
            BSTNode root = new BSTNode(a[mid], null);

            root.Parent = parent;
            root.LeftChild = StartGenerateTree(a, start, mid - 1, level + 1, root);
            root.RightChild = StartGenerateTree(a, mid + 1, end, level + 1, root);
            root.Level = level;

            return root;
        }

        public bool IsBalanced(BSTNode root_node)
        {
            if (root_node == null) return false;

            var levels = GetLeafLevels(root_node);
            levels.Sort();

            if (levels.Last() - levels.First() > 1) return false;
            return true;
        }

        public List<int> GetLeafLevels(BSTNode root_node)
        {
            if (root_node == null) return null;
            List<int> levels = new List<int>();
            StartGetLeafLevels(root_node, ref levels);
            return levels;
        }
        private void StartGetLeafLevels(BSTNode root, ref List<int> levels)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                levels.Add(root.Level);
                return;
            }
            else
            {
                if (root.LeftChild != null)
                {
                    StartGetLeafLevels(root.LeftChild, ref levels);
                }
                if (root.RightChild != null)
                {
                    StartGetLeafLevels(root.RightChild, ref levels);
                }
            }
        }
    }
}

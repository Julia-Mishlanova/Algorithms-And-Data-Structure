using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class BSTNode<T>
    {
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        public BSTNode<T> Root;

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> find = new BSTFind<T>();
            StartFindNode(Root, key, ref find);
            return find;
        }
        private void StartFindNode(BSTNode<T> root, int key, ref BSTFind<T> find)
        {
            if (root == null) return;

            if (root.NodeKey == key)
            {
                find.NodeHasKey = true;
                find.Node = root;
                return;
            }

            if (root.LeftChild == null && root.RightChild == null)
            {
                if (root.NodeKey > key) find.ToLeft = true;
                find.Node = root;
                return;
            }
            else if (root.LeftChild == null)
            {
                if (root.NodeKey > key)
                {
                    find.NodeHasKey = false;
                    find.ToLeft = true;
                    find.Node = root;
                    return;
                }
            }
            else if (root.RightChild == null)
            {
                if (root.NodeKey < key)
                {
                    find.NodeHasKey = false;
                    find.ToLeft = false;
                    find.Node = root;
                    return;
                }
            }
            if (root.NodeKey > key)
            {
                StartFindNode(root.LeftChild, key, ref find);
            }
            if (root.NodeKey < key)
            {
                StartFindNode(root.RightChild, key, ref find);
            }
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }

            bool keyExist = false;
            KeyExist(Root, key, ref keyExist);
            if (keyExist) return false;

            BSTNode<T> nodeToAdd = new BSTNode<T>(key, val, null);
            StartAdd(Root, nodeToAdd);
            return true;
        }
        public void KeyExist(BSTNode<T> root, int key, ref bool keyExist)
        {
            if (root == null) return;

            if (root.NodeKey == key)
            {
                keyExist = true;
                return;
            }

            if (root.LeftChild == null && root.RightChild == null)
            {
                return;
            }
            else
            {
                if (root.NodeKey > key)
                {
                    KeyExist(root.LeftChild, key, ref keyExist);
                }
                if (root.NodeKey < key)
                {
                    KeyExist(root.RightChild, key, ref keyExist);
                }
            }
        }
        private void StartAdd(BSTNode<T> root, BSTNode<T> nodeToAdd)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                if (root.NodeKey < nodeToAdd.NodeKey) root.RightChild = nodeToAdd;
                else root.LeftChild = nodeToAdd;

                nodeToAdd.Parent = root;
                return;
            }
            else if (root.LeftChild == null)
            {
                if (root.NodeKey > nodeToAdd.NodeKey)
                {
                    root.LeftChild = nodeToAdd;
                    nodeToAdd.Parent = root;
                    return;
                }
            }
            else if (root.RightChild == null)
            {
                if (root.NodeKey < nodeToAdd.NodeKey)
                {
                    root.RightChild = nodeToAdd;
                    nodeToAdd.Parent = root;
                    return;
                }
            }

            if (root.NodeKey > nodeToAdd.NodeKey)
            {
                StartAdd(root.LeftChild, nodeToAdd);
            }
            if (root.NodeKey < nodeToAdd.NodeKey)
            {
                StartAdd(root.RightChild, nodeToAdd);
            }
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (Root == null) return null;

            BSTNode<T> node = new BSTNode<T>(0, default, null);
            if (FindMax)
            {
                FindMaximum(FromNode, ref node);
            }
            if (!FindMax)
            {
                FindMinimum(FromNode, ref node);
            }
            return node;
        }
        private void FindMaximum(BSTNode<T> root, ref BSTNode<T> max)
        {
            if (root == null) return;

            if (root.LeftChild == null && root.RightChild == null)
            {
                max = root;
                return;
            }
            else
            {
                FindMaximum(root.RightChild, ref max);
            }
        }
        private void FindMinimum(BSTNode<T> root, ref BSTNode<T> min)
        {
            if (root == null) return;

            if (root.LeftChild == null && root.RightChild == null)
            {
                min = root;
                return;
            }
            else
            {
                FindMinimum(root.LeftChild, ref min);
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            var node = FindNodeByKey(key);
            if (node.NodeHasKey == false) return false;

            var rigth = node.Node.RightChild;
            var left = node.Node.LeftChild;

            if (rigth == null && left == null) 
            {
                if (node.Node == node.Node.Parent.RightChild)
                {
                    node.Node.Parent.RightChild = null;
                }
                if (node.Node == node.Node.Parent.LeftChild)
                {
                    node.Node.Parent.LeftChild = null;
                }
                node.Node = null;
                return true;
            }

            if (rigth == null)
            {
                var max = FinMinMax(left, true);
                node.Node.NodeKey = max.NodeKey;
                node.Node.NodeValue = max.NodeValue;
                max.Parent.RightChild = null;
                return true;
            }

            if (rigth.LeftChild == null)
            {
                node.Node.NodeKey = rigth.NodeKey;
                node.Node.NodeValue = rigth.NodeValue;
                node.Node.RightChild = rigth.RightChild;
                return true;
            }

            var min = FinMinMax(rigth, false);
            node.Node.NodeKey = min.NodeKey;
            node.Node.NodeValue = min.NodeValue;
            min.Parent.LeftChild = null;
            return true;
        }

        public int Count()
        {
            if (Root == null) return 0;

            int count = 0;
            StartCounting(Root, ref count);
            return count;
        }
        private void StartCounting(BSTNode<T> root, ref int count)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                count++;
                return;
            }
            else
            {
                count++;
                if (root.LeftChild != null)
                {
                    StartCounting(root.LeftChild, ref count);
                }
                if (root.RightChild != null)
                {
                    StartCounting(root.RightChild, ref count);
                }
            }
        }

        public List<BSTNode<T>> WideAllNodes()
        {
            if (Root == null) return null;

            List<BSTNode<T>> result = new List<BSTNode<T>>() { Root, Root.LeftChild, Root.RightChild };
            List<BSTNode<T>> currLayer = new List<BSTNode<T>>() { Root.LeftChild, Root.RightChild };

            StartWideAllNodes(ref result, ref currLayer);
            return result;
        }

        private void StartWideAllNodes(ref List<BSTNode<T>> result, ref List<BSTNode<T>> currLayer)
        {
            if (result.Count == Count()) return;
            List<BSTNode<T>> nextLayer = new List<BSTNode<T>>();

            foreach (BSTNode<T> node in currLayer)
            {
                if (node == null) continue;

                nextLayer.Add(node.LeftChild);
                nextLayer.Add(node.RightChild);
            }
            currLayer = nextLayer;
            result.AddRange(currLayer);

            StartWideAllNodes(ref result, ref currLayer);
        }

        public List<BSTNode<T>> DeepAllNodes()
        {
            List<BSTNode<T>> result = new List<BSTNode<T>>();
            StartDeepAllNodes(Root, ref result);
            return result;
        }

        private void StartDeepAllNodes(BSTNode<T> root, ref List<BSTNode<T>> result)
        {
            if (root.LeftChild == null && root.RightChild == null)
            {
                result.Add(root);
                return;
            }
            else
            {
                result.Add(root);
                if (root.LeftChild != null)
                {
                    StartDeepAllNodes(root.LeftChild, ref result);
                }
                if (root.RightChild != null)
                {
                    StartDeepAllNodes(root.RightChild, ref result);
                }
            }
        }
    }
}

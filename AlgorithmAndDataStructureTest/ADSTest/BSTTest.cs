using ConsoleApp4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace joolTest
{
    [TestClass]
    public class BSTTest
    {
        [TestMethod]
        public void SearchAllNodeTest()
        {
            BSTNode<char> root = new BSTNode<char>(8, 'a', null);
            BST<char> tree = new BST<char>(root);

            tree.AddKeyValue(4, 'b');
            tree.AddKeyValue(12, 'c');
            tree.AddKeyValue(2, 'd');
            tree.AddKeyValue(6, 'e');
            tree.AddKeyValue(10, 'f');
            tree.AddKeyValue(14, 'g');
            tree.AddKeyValue(1, 'h');
            tree.AddKeyValue(3, 'i');
            tree.AddKeyValue(5, 'j');
            tree.AddKeyValue(7, 'k');
            tree.AddKeyValue(9, 'l');
            tree.AddKeyValue(11, 'm');
            tree.AddKeyValue(13, 'n');
            tree.AddKeyValue(15, 'o');

            var nodesWide = tree.WideAllNodes();
            string alphabet = "abcdefghijklmno";

            for (int i = 0; i < nodesWide.Count; i++)
            {
                Assert.AreEqual(alphabet[i], nodesWide[i].NodeValue);
            }

            string res = string.Empty;
            var nodesDeep = tree.DeepAllNodes();
            Assert.AreEqual(nodesDeep.Count, alphabet.Length);
            for (int i = 0; i < nodesDeep.Count; i++)
            {
                res += nodesDeep[i].NodeValue;
            }
        }
        [TestMethod]
        public void TestTree1()
        {
            BSTNode<int> root = new BSTNode<int>(8, 8, null);
            BST<int> tree = new BST<int>(root);

            // только корень
            var coc = tree.Count();
            Assert.AreEqual(1, coc);

            // add
            tree.AddKeyValue(4, 4);

            var go = tree.AddKeyValue(12, 12);
            var gog = tree.AddKeyValue(12, 12);
            Assert.IsFalse(gog);

            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(6, 6);
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(14, 14);
            tree.AddKeyValue(1, 1);

            var bogo = tree.AddKeyValue(3, 3);
            var bo = tree.AddKeyValue(3, 3);
            Assert.IsFalse(bo);

            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(7, 7);
            tree.AddKeyValue(9, 9);
            tree.AddKeyValue(11, 11);
            tree.AddKeyValue(13, 13);
            tree.AddKeyValue(15, 15);

            // min max
            var min = tree.FinMinMax(root, false);
            Assert.AreEqual(1, min.NodeKey);
            var max = tree.FinMinMax(root, true);
            Assert.AreEqual(15, max.NodeKey);

            // count
            var count = tree.Count();
            Assert.AreEqual(15, count);

            var node = tree.FindNodeByKey(8);
            var node0 = tree.FindNodeByKey(4);
            var node1 = tree.FindNodeByKey(12);
            var node2 = tree.FindNodeByKey(2);
            var node3 = tree.FindNodeByKey(6);
            var node4 = tree.FindNodeByKey(10);
            var node5 = tree.FindNodeByKey(14);
            var node6 = tree.FindNodeByKey(1);
            var node7 = tree.FindNodeByKey(3);
            var node8 = tree.FindNodeByKey(5);
            var node9 = tree.FindNodeByKey(7);
            var node10 = tree.FindNodeByKey(9);
            var node11 = tree.FindNodeByKey(11);
            var node12 = tree.FindNodeByKey(13);
            var node15 = tree.FindNodeByKey(15);

            tree.DeleteNodeByKey(12);
            tree.DeleteNodeByKey(10);
            tree.DeleteNodeByKey(9);
            tree.DeleteNodeByKey(11);
            tree.DeleteNodeByKey(15);
            tree.DeleteNodeByKey(4);
            tree.DeleteNodeByKey(8);
        }

        [TestMethod]
        public void TestTree2()
        {
            /*
             *       8
             *      / \
             *     4  12
             *    / \
             *   2   5
             *  / \
             * 1   3
             * 
             */

            BSTNode<int> root = new BSTNode<int>(8, 8, null);
            BST<int> tree = new BST<int>(root);

            // add
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(2, 2);
            tree.AddKeyValue(5, 5);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(3, 3);

            // min max
            var min = tree.FinMinMax(root, false);
            Assert.AreEqual(1, min.NodeKey);
            var max = tree.FinMinMax(root, true);
            Assert.AreEqual(12, max.NodeKey);

            // count
            var count = tree.Count();
            Assert.AreEqual(7, count);

            // find
            var node = tree.FindNodeByKey(8);
            Assert.AreEqual(8, node.Node.NodeKey);

            var node0 = tree.FindNodeByKey(4);
            Assert.AreEqual(4, node0.Node.NodeKey);

            var node1 = tree.FindNodeByKey(12);
            Assert.AreEqual(12, node1.Node.NodeKey);

            var node2 = tree.FindNodeByKey(2);
            Assert.AreEqual(2, node2.Node.NodeKey);

            var node3 = tree.FindNodeByKey(5);
            Assert.AreEqual(5, node3.Node.NodeKey);

            var node4 = tree.FindNodeByKey(1);
            Assert.AreEqual(1, node4.Node.NodeKey);

            var node5 = tree.FindNodeByKey(3);
            Assert.AreEqual(3, node5.Node.NodeKey);


            // not exist key example
            var node6 = tree.FindNodeByKey(100);
            Assert.AreEqual(12, node6.Node.NodeKey);
            Assert.AreEqual(false, node6.NodeHasKey);
            Assert.AreEqual(false, node6.ToLeft);

            var node7 = tree.FindNodeByKey(0);
            Assert.AreEqual(1, node7.Node.NodeKey);
            Assert.AreEqual(false, node7.NodeHasKey);
            Assert.AreEqual(true, node7.ToLeft);

            var node8 = tree.FindNodeByKey(10);
            Assert.AreEqual(12, node8.Node.NodeKey);
            Assert.AreEqual(false, node8.NodeHasKey);
            Assert.AreEqual(true, node8.ToLeft);

            var node9 = tree.FindNodeByKey(7);
            Assert.AreEqual(5, node9.Node.NodeKey);
            Assert.AreEqual(false, node9.NodeHasKey);
            Assert.AreEqual(false, node9.ToLeft);
        }

        [TestMethod]
        public void TestTree3()
        {
            /*
             *        8
             *       / \
             *      4   12
             *         /  \
             *        10  15
             *       /  \
             *      9   11   
             */

            BSTNode<int> root = new BSTNode<int>(8, 8, null);
            BST<int> tree = new BST<int>(root);

            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(15, 15);
            tree.AddKeyValue(10, 10);
            tree.AddKeyValue(9, 9);
            tree.AddKeyValue(11, 11);

            // min max
            var min = tree.FinMinMax(root, false);
            Assert.AreEqual(4, min.NodeKey);
            var max = tree.FinMinMax(root, true);
            Assert.AreEqual(15, max.NodeKey);

            // count
            var count = tree.Count();
            Assert.AreEqual(7, count);

            // find
            var node = tree.FindNodeByKey(8);
            Assert.AreEqual(8, node.Node.NodeKey);

            var node0 = tree.FindNodeByKey(4);
            Assert.AreEqual(4, node0.Node.NodeKey);

            var node1 = tree.FindNodeByKey(12);
            Assert.AreEqual(12, node1.Node.NodeKey);

            var node2 = tree.FindNodeByKey(15);
            Assert.AreEqual(15, node2.Node.NodeKey);

            var node3 = tree.FindNodeByKey(10);
            Assert.AreEqual(10, node3.Node.NodeKey);

            var node4 = tree.FindNodeByKey(9);
            Assert.AreEqual(9, node4.Node.NodeKey);

            var node5 = tree.FindNodeByKey(11);
            Assert.AreEqual(11, node5.Node.NodeKey);

            // not exist key example
            var node6 = tree.FindNodeByKey(90);
            Assert.AreEqual(15, node6.Node.NodeKey);
            Assert.AreEqual(false, node6.NodeHasKey);
            Assert.AreEqual(false, node6.ToLeft);

            var node7 = tree.FindNodeByKey(2);
            Assert.AreEqual(4, node7.Node.NodeKey);
            Assert.AreEqual(false, node7.NodeHasKey);
            Assert.AreEqual(true, node7.ToLeft);
        }

        [TestMethod]
        public void TestTreeForDeleteNode()
        {
            /*
             *      5
             *     / \
             *    3   9
             *   / \   \
             *  1   4   12
             *         /
             *        11
             */

            //Если мы находим правый узел удаляемого узла, у которого есть только правый потомок,
            //то преемником берём этот узел, а вместо него помещаем его правого потомка.

            BSTNode<int> root = new BSTNode<int>(5, 5, null);
            BST<int> tree = new BST<int>(root);

            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(9, 9);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(11, 11);

            tree.DeleteNodeByKey(5);

            /*       
             *        9 
             *      /  \
             *     /    \
             *    3     12
             *   / \   /
             *  1   4 11
             *        
             */
        }

        [TestMethod]
        public void TestTreeForDeleteNode2()
        {
            /*
             *      5
             *     / 
             *    3   
             *   / \   
             *  1   4   
             *        
             */

            // случай если правого потомка у удаляемой не будет, а нам надо направо.
            // Идем налево, затем спуск по правым, как бы реверсируя ход

            BSTNode<int> root = new BSTNode<int>(5, 5, null);
            BST<int> tree = new BST<int>(root);

            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(4, 4);

            tree.DeleteNodeByKey(5);
            /*
             *      4
             *     / 
             *    3   
             *   /   
             *  1      
             *        
             */
        }

        [TestMethod]
        public void TestTreeForDeleteLeave()
        {
            /*
             *      5
             *     / \
             *    3   9
             *   / \   \
             *  1   4   12
             *         /
             *        11
             */

            BSTNode<int> root = new BSTNode<int>(5, 5, null);
            BST<int> tree = new BST<int>(root);

            tree.AddKeyValue(3, 3);
            tree.AddKeyValue(9, 9);
            tree.AddKeyValue(1, 1);
            tree.AddKeyValue(4, 4);
            tree.AddKeyValue(12, 12);
            tree.AddKeyValue(11, 11);

            tree.DeleteNodeByKey(11); // не находит левые листья
            tree.DeleteNodeByKey(4);
            tree.DeleteNodeByKey(1); // не находит левые листья

            /*
             *      5
             *     / \
             *    3   9
             *         \
             *          12
             */

            tree.DeleteNodeByKey(11);
            tree.DeleteNodeByKey(11);
        }
    }
}

using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joolTest
{
    [TestClass]
    public class SimpleTreeTest
    {
        [TestMethod]
        public void TestTree1()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);

            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, null);

            SimpleTree<int> tree = new SimpleTree<int>(root);

            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(root, node4);

            tree.AddChild(node2, node5);
            tree.AddChild(node2, node6);

            tree.AddChild(node4, node7);

            tree.AddChild(node7, node8);
            tree.AddChild(node7, node9);

            // not exist node
            tree.AddChild(node10, node9);

            var count = tree.Count();
            Assert.AreEqual(9, count);

            var nodes = tree.GetAllNodes();
            Assert.AreEqual(9, nodes.Count);

            var specNodes = new List<SimpleTreeNode<int>>();
            for (int i = 0; i < 10; i++)
            {
                specNodes.AddRange(tree.FindNodesByValue(i));
            }
            var leaf = tree.LeafCount(); //5
            Assert.AreEqual(5, leaf);

            tree.MoveNode(node7, node6);
            // tree.MoveNode(root, node6);

            tree.DeleteNode(node9);
            Assert.AreEqual(0, tree.FindNodesByValue(9).Count);

            tree.DeleteNode(node8);
            Assert.AreEqual(0, tree.FindNodesByValue(8).Count);

            tree.DeleteNode(node7);
            Assert.AreEqual(0, tree.FindNodesByValue(7).Count);

            tree.DeleteNode(node6);
            Assert.AreEqual(0, tree.FindNodesByValue(6).Count);

            tree.DeleteNode(node5);
            Assert.AreEqual(0, tree.FindNodesByValue(5).Count);

            tree.DeleteNode(node4);
            Assert.AreEqual(0, tree.FindNodesByValue(4).Count);

            tree.DeleteNode(node3);
            Assert.AreEqual(0, tree.FindNodesByValue(3).Count);

            tree.DeleteNode(node2);
            Assert.AreEqual(0, tree.FindNodesByValue(2).Count);

            tree.DeleteNode(root);
            Assert.AreEqual(0, tree.FindNodesByValue(1).Count);

            var count0 = tree.Count();
            Assert.AreEqual(0, count0);
        }

        [TestMethod]
        public void TestTree2()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);

            SimpleTree<int> tree = new SimpleTree<int>(root);

            tree.AddChild(root, node2);
            tree.AddChild(root, node3);

            tree.AddChild(node3, node4);
            tree.AddChild(node3, node5);

            tree.AddChild(node4, node6);

            tree.AddChild(node6, node7);
            tree.AddChild(node6, node8);
            tree.AddChild(node6, node9);

            var count = tree.Count();
            Assert.AreEqual(9, count);

            var nodes = tree.GetAllNodes();
            Assert.AreEqual(9, nodes.Count);

            var specNodes = new List<SimpleTreeNode<int>>();
            for (int i = 0; i < 10; i++)
            {
                specNodes.AddRange(tree.FindNodesByValue(i));
            }
            var leaf = tree.LeafCount(); //5
            Assert.AreEqual(5, leaf);

            tree.DeleteNode(node9);
            Assert.AreEqual(0, tree.FindNodesByValue(9).Count);

            tree.DeleteNode(node8);
            Assert.AreEqual(0, tree.FindNodesByValue(8).Count);

            tree.DeleteNode(node7);
            Assert.AreEqual(0, tree.FindNodesByValue(7).Count);

            tree.DeleteNode(node6);
            Assert.AreEqual(0, tree.FindNodesByValue(6).Count);

            tree.DeleteNode(node5);
            Assert.AreEqual(0, tree.FindNodesByValue(5).Count);

            tree.DeleteNode(node4);
            Assert.AreEqual(0, tree.FindNodesByValue(4).Count);

            tree.DeleteNode(node3);
            Assert.AreEqual(0, tree.FindNodesByValue(3).Count);

            tree.DeleteNode(node2);
            Assert.AreEqual(0, tree.FindNodesByValue(2).Count);

            tree.DeleteNode(root);
            Assert.AreEqual(0, tree.FindNodesByValue(1).Count);

            var count0 = tree.Count();
            Assert.AreEqual(0, count0);
        }

        [TestMethod]

        public void TestEvenTrees()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);

            SimpleTreeNode<int> node2 = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> node3 = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> node6 = new SimpleTreeNode<int>(6, null);

            SimpleTreeNode<int> node8 = new SimpleTreeNode<int>(8, null);
            SimpleTreeNode<int> node7 = new SimpleTreeNode<int>(7, null);
            SimpleTreeNode<int> node4 = new SimpleTreeNode<int>(4, null);
            SimpleTreeNode<int> node5 = new SimpleTreeNode<int>(5, null);

            SimpleTreeNode<int> node9 = new SimpleTreeNode<int>(9, null);
            SimpleTreeNode<int> node10 = new SimpleTreeNode<int>(10, null);

            SimpleTree<int> tree = new SimpleTree<int>(root);

            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(root, node6);

            tree.AddChild(node2, node7);
            tree.AddChild(node2, node5);

            tree.AddChild(node3, node4);

            tree.AddChild(node6, node8);
            tree.AddChild(node8, node9);
            tree.AddChild(node8, node10);

            var trees = tree.EvenTrees();

        }

        [TestMethod]
        public void TestEvenTreesWithNullRoot()
        {
            SimpleTreeNode<int> root = null;

            SimpleTree<int> tree = new SimpleTree<int>(root);

            // Arrange
            // Act
            var result = tree.EvenTrees();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestEvenTreesWithSingleNodeTree()
        {
            // Arrange
            var root = new SimpleTreeNode<int>(1);

            SimpleTree<int> tree = new SimpleTree<int>(root);


            // Act
            var result = tree.EvenTrees();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void TestEvenTreesWithEvenTree()
        {
            // Arrange

            var root = new SimpleTreeNode<int>(1);
            root.Children.Add(new SimpleTreeNode<int>(2));
            root.Children.Add(new SimpleTreeNode<int>(3));
            root.Children[0].Children.Add(new SimpleTreeNode<int>(4));
            root.Children[0].Children.Add(new SimpleTreeNode<int>(5));
            root.Children[1].Children.Add(new SimpleTreeNode<int>(6));
            root.Children[1].Children.Add(new SimpleTreeNode<int>(7));

            SimpleTree<int> tree = new SimpleTree<int>(root);

            // Act
            var result = tree.EvenTrees();

            // Assert
            CollectionAssert.AreEqual(new List<int>() { }, result);
        }

        [TestMethod]
        public void TestEvenTreesWithOddTree()
        {
            // Arrange
            var root = new SimpleTreeNode<int>(1);
            root.Children.Add(new SimpleTreeNode<int>(2));
            root.Children.Add(new SimpleTreeNode<int>(3));
            root.Children[0].Children.Add(new SimpleTreeNode<int>(4));
            root.Children[0].Children.Add(new SimpleTreeNode<int>(5));
            root.Children[1].Children.Add(new SimpleTreeNode<int>(6));
            root.Children[1].Children.Add(new SimpleTreeNode<int>(7));
            root.Children[1].Children.Add(new SimpleTreeNode<int>(8));

            SimpleTree<int> tree = new SimpleTree<int>(root);

            // Act
            var result = tree.EvenTrees();

            // Assert
            CollectionAssert.AreEqual(new List<int>(), result);
        }
    }
}

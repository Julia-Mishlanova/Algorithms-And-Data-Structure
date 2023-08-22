using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp_ADS;

namespace MSTest
{
    [TestClass]
    public class BSTUnitTest
    {
        [TestMethod]
        public void AddChildTest()
        {
            //____
            //____
            var bstTree = new BST<int>(null);
            var zeronotfound = bstTree.FindNodeByKey(0);
            Assert.AreEqual(0, bstTree.Count());
            bstTree.AddKeyValue(8, 8);
            var eightfounded = bstTree.FindNodeByKey(8);
            Assert.AreEqual(1, bstTree.Count());
            bstTree.AddKeyValue(4, 4);
            Assert.AreEqual(2, bstTree.Count());
            bstTree.AddKeyValue(12, 12);
            var founded10 = bstTree.FindNodeByKey(10); // почему если 10 еще не добавили
            Assert.AreEqual(3, bstTree.Count());
            bstTree.AddKeyValue(2, 2);
            var twofounded = bstTree.FindNodeByKey(2);
            Assert.AreEqual(4, bstTree.Count());
            bstTree.AddKeyValue(6, 6);
            Assert.AreEqual(5, bstTree.Count());
            bstTree.AddKeyValue(10, 10);
            Assert.AreEqual(6, bstTree.Count());
            bstTree.AddKeyValue(14, 14);
            Assert.AreEqual(7, bstTree.Count());


            bstTree.AddKeyValue(1, 1);

            bstTree.AddKeyValue(3, 3);

            bstTree.AddKeyValue(5, 5);

            bstTree.AddKeyValue(7, 7);

            bstTree.AddKeyValue(9, 9);

            bstTree.AddKeyValue(11, 11);

            bstTree.AddKeyValue(13, 13);
            var founded15 = bstTree.FindNodeByKey(15);
            bstTree.AddKeyValue(15, 15);

            Assert.AreEqual(15, bstTree.Count());

            var min = bstTree.FinMinMax(bstTree.Root, false);

            var max = bstTree.FinMinMax(bstTree.Root, true);

            var min4 = bstTree.FinMinMax(bstTree.FindNodeByKey(4).Node, false);
            var min12 = bstTree.FinMinMax(bstTree.FindNodeByKey(12).Node, false);
            var max12 = bstTree.FinMinMax(bstTree.FindNodeByKey(12).Node, true);
            var max4 = bstTree.FinMinMax(bstTree.FindNodeByKey(4).Node, true);

            Assert.AreEqual(true, bstTree.DeleteNodeByKey(11));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(10));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(9));

            Assert.AreEqual(true, bstTree.DeleteNodeByKey(8)); ///


            Assert.AreEqual(true, bstTree.DeleteNodeByKey(5));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(4));

            Assert.AreEqual(true, bstTree.DeleteNodeByKey(3));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(2));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(1));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(15));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(14));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(13));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(12));

            Assert.AreEqual(false, bstTree.DeleteNodeByKey(8)); /// почему true было если мы уже удаляли выше и его с нами нет
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(7));
            Assert.AreEqual(true, bstTree.DeleteNodeByKey(6));

            //____

        }
    }
}
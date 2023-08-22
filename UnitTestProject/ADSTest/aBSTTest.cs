using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_ADS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace joolTest
{
    [TestClass]
    public class aBSTTest
    {
        [TestMethod]
        public void Test()
        {
            aBST bST = new aBST(4);
            var length = bST.Tree.Length;

            bST.AddKey(50);
            bST.AddKey(25);
            bST.AddKey(75);
            bST.AddKey(37);
            bST.AddKey(62);
            bST.AddKey(84);
            bST.AddKey(31);
            bST.AddKey(43);
            bST.AddKey(55);
            bST.AddKey(92);

            var a = bST.FindKeyIndex(50);
            Assert.AreEqual(0, a);

            var b = bST.FindKeyIndex(25);
            Assert.AreEqual(1, b);

            var c = bST.FindKeyIndex(75);
            Assert.AreEqual(2, c);

            var d = bST.FindKeyIndex(37);
            Assert.AreEqual(4, d);

            var e = bST.FindKeyIndex(62);
            Assert.AreEqual(5, e);

            var f = bST.FindKeyIndex(84);
            Assert.AreEqual(6, f);

            var g = bST.FindKeyIndex(31);
            Assert.AreEqual(9, g);

            var h = bST.FindKeyIndex(43);
            Assert.AreEqual(10, h);

            var i = bST.FindKeyIndex(55);
            Assert.AreEqual(11, i);

            var j = bST.FindKeyIndex(92);
            Assert.AreEqual(12, j);

            var k = bST.FindKeyIndex(100);
            Assert.AreEqual(null, k);


            aBST abST = new aBST(3);

            abST.AddKey(9);
            abST.AddKey(5);
            abST.AddKey(11);
            abST.AddKey(12);
            abST.AddKey(10);
            abST.AddKey(3);
            abST.AddKey(8);

        }
    }
}

using ConsoleApp_ADS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace joolTest
{
    [TestClass]
    public class BloomFilterTest
    {
        [TestMethod]
        public void Test()
        {
            BloomFilter filter = new BloomFilter(32);

            filter.Add("kakish");
            var bogo = filter.Hash1("kakish");
            var bogo1 = filter.Hash2("kakish");
            Assert.IsTrue(filter.IsValue("kakish"));
            Assert.IsFalse(filter.IsValue("bogdan"));

            filter.Add("ishkak");
            var bogo2 = filter.Hash1("ishkak");
            var bogo3 = filter.Hash2("ishkak");
            Assert.IsTrue(filter.IsValue("ishkak"));

            filter.Add(null);
            var bogo4 = filter.Hash1(null);
            var bogo5 = filter.Hash2(null);
            Assert.IsFalse(filter.IsValue(null));

            filter.Add("a");
            var bogo6 = filter.Hash1("a");
            var bogo7 = filter.Hash2("a");
            Assert.IsTrue(filter.IsValue("a"));

            filter.Add("b");
            var bogo8 = filter.Hash1("b");
            var bogo9 = filter.Hash2("b");
            Assert.IsTrue(filter.IsValue("b"));
            filter.Add("ab");
            var bogo10 = filter.Hash1("ab");
            var bogo11 = filter.Hash2("ab");
            Assert.IsTrue(filter.IsValue("ab"));

            filter.Add("ba");
            var bogo13 = filter.Hash1("ba");
            var bogo12 = filter.Hash2("ba");
            Assert.IsTrue(filter.IsValue("ba"));

            filter.Add("c");
            var bogo14 = filter.Hash1("c");
            var bogo15 = filter.Hash2("c");
            Assert.IsTrue(filter.IsValue("c"));

            filter.Add("d");
            var bogo16 = filter.Hash1("d");
            var bogo17 = filter.Hash2("d");
            Assert.IsTrue(filter.IsValue("d"));

            filter.Add("e");
            var bogo18 = filter.Hash1("e");
            var bogo19 = filter.Hash2("e");
            Assert.IsTrue(filter.IsValue("e"));

            filter.Add("fe");
            var bogo20 = filter.Hash1("fe");
            var bogo21 = filter.Hash2("fe");
            Assert.IsTrue(filter.IsValue("fe"));

            filter.Add("ef");
            var bogo22 = filter.Hash1("ef");
            var bogo23 = filter.Hash2("ef");
            Assert.IsTrue(filter.IsValue("ef"));

            filter.Add("f");
            var bogo24 = filter.Hash1("f");
            var bogo25 = filter.Hash2("f");
            Assert.IsTrue(filter.IsValue("f"));

            filter.Add("ajsdh");
            var bogo26 = filter.Hash1("ajsdh");
            var bogo27 = filter.Hash2("ajsdh");
            Assert.IsTrue(filter.IsValue("ajsdh")); // equal adhjs

            filter.Add("sdfjis");
            var bogo28 = filter.Hash1("sdfjis");
            var bogo29 = filter.Hash2("sdfjis");
            Assert.IsTrue(filter.IsValue("sdfjis"));

            filter.Add("g");
            var bogo30 = filter.Hash1("g");
            var bogo31 = filter.Hash2("g");

            var gog = (filter.IsValue("adhjs"));// t - equal ajsdh
            var bog = filter.Hash1("adhjs");
            var bog1 = filter.Hash2("adhjs");

            var gog1 = (filter.IsValue("dvhjd"));
            var bog2 = filter.Hash1("dvhjd");
            var bog3 = filter.Hash2("dvhjd");

            var gog2 = (filter.IsValue("chajw"));
            var bog4 = filter.Hash1("chajw");
            var bog5 = filter.Hash2("chajw");

            var gog3 = (filter.IsValue("jhcjac"));//t
            var bog6 = filter.Hash1("jhcjac");
            var bog7 = filter.Hash2("jhcjac");

            var gog4 = (filter.IsValue("prkgpr"));
            var bo8 = filter.Hash1("prkgpr");
            var bo9 = filter.Hash2("prkgpr");

            var gog5 = (filter.IsValue("sdivji"));
            var b8 = filter.Hash1("sdivji");
            var b9 = filter.Hash2("sdivji");

        }
    }
}

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
    public class NativeCacheTest
    {
        [TestMethod]
        public void Test()
        {
            NativeCache<int> cache = new NativeCache<int>(5);

            cache.Put("a", 3);
            Assert.AreEqual(3, cache.Get("a"));
            Assert.AreEqual(3, cache.Get("a"));
            Assert.IsTrue(cache.IsKey("a"));

            cache.Put("ab", 23);
            Assert.AreEqual(23, cache.Get("ab"));
            Assert.AreEqual(23, cache.Get("ab"));
            Assert.AreEqual(23, cache.Get("ab"));
            Assert.IsTrue(cache.IsKey("ab"));

            cache.Put("ba", 21);
            Assert.AreEqual(21, cache.Get("ba"));
            Assert.AreEqual(21, cache.Get("ba"));
            Assert.AreEqual(21, cache.Get("ba"));
            Assert.AreEqual(21, cache.Get("ba"));
            Assert.IsTrue(cache.IsKey("ba"));

            cache.Put("c", 31);
            Assert.AreEqual(31, cache.Get("c"));
            Assert.AreEqual(31, cache.Get("c"));
            Assert.AreEqual(31, cache.Get("c"));
            Assert.IsTrue(cache.IsKey("c"));

            cache.Put("e", 367);
            Assert.AreEqual(367, cache.Get("e"));
            Assert.IsTrue(cache.IsKey("e"));

            cache.Put("a", 36);

            cache.Put("e", 367);
            Assert.AreEqual(367, cache.Get("e"));
            Assert.AreEqual(367, cache.Get("e"));
            Assert.AreEqual(367, cache.Get("e"));
            Assert.AreEqual(367, cache.Get("e"));
            Assert.AreEqual(367, cache.Get("e"));
            Assert.AreEqual(367, cache.Get("e"));
            Assert.IsTrue(cache.IsKey("e"));

            cache.Put("h", 312);
            Assert.AreEqual(312, cache.Get("h"));
            Assert.AreEqual(312, cache.Get("h"));
            Assert.AreEqual(312, cache.Get("h"));
            Assert.AreEqual(312, cache.Get("h"));
            Assert.AreEqual(312, cache.Get("h"));

            Assert.IsTrue(cache.IsKey("h"));

            cache.Put("g", 44); // remove из словаря при погружении в FindLessHits
            Assert.AreEqual(44, cache.Get("g"));
            Assert.AreEqual(44, cache.Get("g"));
            Assert.AreEqual(44, cache.Get("g"));
            Assert.IsTrue(cache.IsKey("g"));

            cache.Put("n", 56);
            Assert.AreEqual(56, cache.Get("n"));
            Assert.AreEqual(56, cache.Get("n"));
            Assert.AreEqual(56, cache.Get("n"));
            Assert.AreEqual(56, cache.Get("n"));
            Assert.IsTrue(cache.IsKey("n"));

            cache.Put("o", 284); // должен заменить о как слот с самой низкой статистикой. size 10
            Assert.AreEqual(284, cache.Get("o"));
            Assert.IsTrue(cache.IsKey("o"));

            cache.Put("sdfdsf", 32);
            cache.Put("hjkhjk", 45);
            Assert.IsFalse(cache.IsKey("o"));
            cache.Put("awxcvf", 34);
            cache.Put("jliyuk", 32);
            cache.Put("wefew ffew", 367);
        }
    }
}

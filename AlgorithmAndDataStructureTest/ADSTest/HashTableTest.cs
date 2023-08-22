using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using System.Collections;

namespace joolTest
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void TestTable()
        {
            var hash = new HashTable(10, 1);

            hash.Put("a");
            var gog = hash.Find("a");
            var gog1 = hash.HashFun("a");

            hash.Put("b");
            var gog2 = hash.Find("b");
            var gog3 = hash.HashFun("b");

            hash.Put("ab");
            var gog4 = hash.Find("ab");
            var gog5 = hash.HashFun("ab");

            hash.Put("cba");
            var gog6 = hash.Find("cba");
            var gog7 = hash.HashFun("cba");
            //"acb"

            var gog8 = hash.Find("abc");
            var gog9 = hash.HashFun("abc");

            hash.Put("bac");
            var gogi = hash.HashFun("bac");
            var gogi1 = hash.Find("bac");

            // doesn't allow any duplicate values to be stored
            var h = hash.Put("c");
            var gogi2 = hash.HashFun("c");
            var gogi13 = hash.Find("c");

            var h1 = hash.Put("c");
            var gogi24 = hash.HashFun("c");
            var gogi135 = hash.Find("c");

            var h2 = hash.Put("c");
            var gogi26 = hash.HashFun("c");
            var gogi137 = hash.Find("c");

            hash.Put("d");
            var gogi21 = hash.HashFun("d");
            var gogi131 = hash.Find("d");

            hash.Put("de");
            var gogi21w = hash.HashFun("de");
            var gogi131w = hash.Find("de");

            hash.Put("acb");
            var go = hash.HashFun("acb");
            var go1 = hash.Find("acb");

            hash.Put("cab");
            var go4 = hash.HashFun("cab");
            var go13 = hash.Find("cab");

            hash.Put("z");
            var go9 = hash.HashFun("z");
            var go19 = hash.Find("z");
        }

        [TestMethod]
        public void SpecialTest()
        {
            var hash = new HashTable(0, 1);

            hash.Put("a");
            var gog = hash.Find("a");
            var gog1 = hash.HashFun("a");

            hash.Put("b");
            var gog2 = hash.Find("b");
            var gog3 = hash.HashFun("b");

            hash.Put("ab");
            var gog4 = hash.Find("ab");
            var gog5 = hash.HashFun("ab");

            var hash1 = new HashTable(1, 1);

            hash1.Put("a");
            var gog6 = hash1.Find("a");
            var gog7 = hash1.HashFun("a");

            hash1.Put("b");
            var gog8 = hash1.Find("b");
            var gog9 = hash.HashFun("b");

            hash.Put("ab");
            var gog10 = hash1.Find("ab");
            var gog11 = hash1.HashFun("ab");
        }

    }
}

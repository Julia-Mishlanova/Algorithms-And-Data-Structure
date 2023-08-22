using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;

namespace joolTest
{
    [TestClass]
    public class OrderedListTest
    {
        [TestMethod]
        public void AddAscendingTest()
        {
            bool _ascending = false;

            OrderedList<int> orderedNums = new OrderedList<int>(_ascending);

            orderedNums.Add(2);
            orderedNums.Add(3);
            orderedNums.Add(5);
            orderedNums.Add(5);
            orderedNums.Add(4);
            orderedNums.Add(3); //
            orderedNums.Add(1);

            OrderedList<bool> orderedBool = new OrderedList<bool>(_ascending);

            orderedBool.Add(false); //
            orderedBool.Add(true);
            orderedBool.Add(false);
            orderedBool.Add(false);
            orderedBool.Add(true);

            List<string> str = new List<string>() { "aac", "aaa", "aaA", "aaAAuvvvvuu", "A", "B" }; // "aaa" "aaA" "aaAAuvvvvuu" "aac" "B"

            OrderedList<string> testListStringAscending = new OrderedList<string>(_ascending);
            for (int i = 0; i < str.Count; i++)
            {
                testListStringAscending.Add(str[i]);
            }

            OrderedList<string> testListString = new OrderedList<string>(_ascending);

            testListString.Add("a");
            testListString.Add("ab");
            testListString.Add("ba");
            testListString.Add("abb");
            testListString.Add("abc");
            testListString.Add("abbc");
            testListString.Add("accbc");
            testListString.Add("abcbccc");
            testListString.Add("ba");
            testListString.Add("bac");

            OrderedList<string> testListString1 = new OrderedList<string>(_ascending);
            List<string> strings = new List<string>() { "honeydew", "fig", "apple", "kiwi", "lemon", "date", "biscuit", "basket", "assassin", "bottle", "cherry", "banana", };
            for (int i = 0; i < strings.Count; i++)
            {
                testListString1.Add(strings[i]);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            var orderedAscendingNums = new OrderedList<int>(true);

            orderedAscendingNums.Add(2);
            orderedAscendingNums.Add(3);
            orderedAscendingNums.Add(5);
            orderedAscendingNums.Add(16);
            orderedAscendingNums.Add(4);
            orderedAscendingNums.Add(9); //
            orderedAscendingNums.Add(1);

            orderedAscendingNums.Delete(9);
            orderedAscendingNums.Delete(16);
            orderedAscendingNums.Delete(5);
            orderedAscendingNums.Delete(4);
            orderedAscendingNums.Delete(3);
            orderedAscendingNums.Delete(0);
            orderedAscendingNums.Delete(2);
            orderedAscendingNums.Delete(1);
            orderedAscendingNums.Delete(1);
            orderedAscendingNums.Delete(1);
            orderedAscendingNums.Delete(100);

            Assert.AreEqual(0, orderedAscendingNums.Count());

            /////
            var orderedNums = new OrderedList<int>(false);

            orderedAscendingNums.Add(2);
            orderedAscendingNums.Add(3);
            orderedAscendingNums.Add(5);
            orderedAscendingNums.Add(16);
            orderedAscendingNums.Add(4);
            orderedAscendingNums.Add(9); //
            orderedAscendingNums.Add(1);

            orderedNums.Delete(1);
            orderedNums.Delete(1);
            orderedNums.Delete(1);
            orderedNums.Delete(2);
            orderedNums.Delete(0);
            orderedNums.Delete(3);
            orderedNums.Delete(4);
            orderedNums.Delete(5);
            orderedNums.Delete(16);
            orderedNums.Delete(9);
            orderedNums.Delete(0);

            Assert.AreEqual(0, orderedNums.Count());
        }

        [TestMethod]
        public void FindTest()
        {
            bool _ascending = false;


            // int find
            List<int> ints = new List<int>() { 5, 7, 8, 10, 10, 12, 14, 17, 19, 20, 25, 29 };
            OrderedList<int> list = new OrderedList<int>(_ascending);
            for (int i = 0; i < ints.Count; i++)
            {
                list.Add(ints[i]);
            }
            List<int> canFind = new List<int>();
            for (int i = 0; i < ints.Count; i++)
            {
                canFind.Add(list.Find(ints[i]).value);
            }


            OrderedList<int> ordered = new OrderedList<int>(_ascending); // 100 nums
            for (int i = 0; i < 100; i++)
            {
                ordered.Add(i + 1);
            }
            List<int> canFind1 = new List<int>();
            for (int i = 0; i < ordered.Count(); i++)
            {
                canFind1.Add(ordered.Find(i + 1).value);
            }
            int zeroCount = 0;
            for (int i = 0; i < canFind1.Count; i++)
            {
                if (canFind1[i] == 0) zeroCount++;
            }
            Assert.AreEqual(0, zeroCount);


            OrderedList<int> ordered1 = new OrderedList<int>(_ascending); // 1000 nums
            for (int i = 0; i < 1000; i++)
            {
                ordered1.Add(i + 1);
            }
            List<int> find = new List<int>();
            for (int i = 0; i < ordered1.Count(); i++)
            {
                find.Add(ordered1.Find(i + 1).value);
            }
            int zeroCount1 = 0;
            for (int i = 0; i < find.Count; i++)
            {
                if (find[i] == 0) zeroCount1++;
            }
            Assert.AreEqual(0, zeroCount1);

            // string find
            OrderedList<string> testListString = new OrderedList<string>(_ascending);
            List<string> strings = new List<string>() { "honeydew", "fig", "apple", "kiwi", "lemon", "date", "biscuit", "basket", "assassin", "bottle", "cherry", "banana", };
            // apple assassin banana basket biscuit bottle cherry date fig honeydew kiwi lemon
            for (int i = 0; i < strings.Count; i++)
            {
                testListString.Add(strings[i]);
            }
            List<string> canFind3 = new List<string>();
            for (int i = 0; i < strings.Count; i++)
            {
                canFind3.Add(testListString.Find(strings[i]).value);
            }
        }
    }

}

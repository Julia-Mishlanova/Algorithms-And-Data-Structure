using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp_ADS;

namespace joolTest
{
    [TestClass]
    public class PowerSetTest
    {
        [TestMethod]
        public void Test()
        {
            PowerSet<string> set = new PowerSet<string>(20, 1);

            List<string> strings = new List<string>() { "honeydew", "fig", "apple", "kiwi", "lemon", "date", "biscuit", "basket", "assassin", "bottle", "cherry", "banana" };
            for (int i = 0; i < strings.Count; i++)
            {
                set.Put(strings[i]);
            }

            PowerSet<string> set1 = new PowerSet<string>(12, 1);

            for (int i = 0; i < strings.Count / 2; i++)
            {
                set1.Put(strings[i]);
            }

            var gog = set.Intersection(set1);
            var gog2 = set.Difference(set1);
        }

        [TestMethod]
        public void TestIntersection()
        {
            PowerSet<string> set = new PowerSet<string>(10, 1);

            List<string> strings = new List<string>() { "lemon", "lemon", "monle", "honeydew", "fig", "apple", "kiwi", "monle", "monle" };
            for (int i = 0; i < strings.Count; i++)
            {
                set.Put(strings[i]);
            }

            List<string> strings1 = new List<string>() { "honeydew", "fig", "apple", "dewhoney", "fig" };
            PowerSet<string> set1 = new PowerSet<string>(10, 1);

            for (int i = 0; i < strings1.Count; i++)
            {
                set1.Put(strings1[i]);
            }

            var gog = set.Intersection(set1); // в большом ищем маленький
            var gog1 = set1.Intersection(set);
        }

        [TestMethod]
        public void TestDifference()
        {
            PowerSet<string> set1 = new PowerSet<string>(20, 1);

            List<string> strings = new List<string>() { "Apple", "Banana", "Cherry", "Date", "Eggplant", "Fennel", "Grape", "Tomato" };
            for (int i = 0; i < strings.Count; i++)
            {
                set1.Put(strings[i]);
            }

            PowerSet<string> set = new PowerSet<string>(10, 1);
            for (int i = 0; i < strings.Count / 2; i++)
            {
                set.Put(strings[i]);
            }

            var gog = set.Difference(set1);
            var gog1 = set1.Difference(set);


            PowerSet<int> powerSet = new PowerSet<int>(10, 1);

            List<int> ints = new List<int>() { 1, 2, 3, 4, 5 };

            for (int i = 0; i < ints.Count; i++)
            {
                powerSet.Put(ints[i]);
            }

            PowerSet<int> powerSet1 = new PowerSet<int>(6, 1);

            List<int> ints1 = new List<int>() { 1, 2, 3 };

            for (int i = 0; i < ints1.Count; i++)
            {
                powerSet1.Put(ints[i]);
            }

            // powerSet = 1, 2, 3, 4, 5
            // powerSet1 = 1, 2, 3
            var gog43 = powerSet.Intersection(powerSet1); // 1, 2 ,3
            var gog34 = powerSet1.Intersection(powerSet); // 1, 2 ,3

            var gog2 = powerSet.Difference(powerSet1); // 4, 5
            var gog3 = powerSet1.Difference(powerSet); // 4, 5

        }

        [TestMethod]
        public void TestFind()
        {
            // small size set
            PowerSet<string> set = new PowerSet<string>(4, 1);
            List<string> strings = new List<string>() { "Apple", "Banana", "Cherry", "Date", "Eggplant", "Fennel", "Grape", "Honeydew", "Iceberg lettuce", "Jackfruit", "Kiwi", "Lemon", "Mango", "Nectarine", "Orange", "Papaya", "Quince", "Raspberry", "Strawberry", "Tomato" };
            for (int i = 0; i < strings.Count; i++)
            {
                set.Put(strings[i]);
            }

            List<int> canFind = new List<int>();
            for (int i = 0; i < strings.Count; i++)
            {
                canFind.Add(set.Find(strings[i]));
            }

            // All elements List<string> strings
            PowerSet<string> set1 = new PowerSet<string>(20, 1);
            for (int i = 0; i < strings.Count; i++)
            {
                set1.Put(strings[i]);
            }

            List<int> canFind1 = new List<int>();
            for (int i = 0; i < strings.Count; i++)
            {
                canFind1.Add(set1.Find(strings[i]));
            }

            // "Apple" 18, "Banana" 17, "Cherry" 1, "Date" 2, "Eggplant" 19, "Fennel" 0, "Grape" 15, "Honeydew" 16, "Iceberg lettuce" 3, "Jackfruit" 11, "Kiwi" 4, "Lemon" 7, "Mango" 5, "Nectarine" 6, "Orange" 8, "Papaya" 9, "Quince" 13, "Raspberry" 14, "Strawberry" 10, "Tomato" 12
            List<int> ExpectedInd = new List<int> { 18, 17, 1, 2, 19, 0, 15, 16, 3, 11, 4, 7, 5, 6, 8, 9, 13, 14, 10, 12 };
            for (int i = 0; i < ExpectedInd.Count; i++)
            {
                Assert.AreEqual(ExpectedInd[i], canFind1[i]);
            }
        }

        [TestMethod]
        public void TestUnion()
        {
            PowerSet<string> set = new PowerSet<string>(10, 1);

            List<string> strings = new List<string>() { "honeydew", "fig", "apple", "kiwi", "lemon", "date" };
            for (int i = 0; i < strings.Count; i++)
            {
                set.Put(strings[i]);
            }

            List<string> strings1 = new List<string>() { "biscuit", "basket", "assassin", "bottle", "cherry", "banana" };
            PowerSet<string> set1 = new PowerSet<string>(10, 1);

            for (int i = 0; i < strings1.Count; i++)
            {
                set1.Put(strings1[i]);
            }

            var un = set1.Union(set);
        }

        [TestMethod]
        public void IsSubsetTest()
        {
            PowerSet<char> set = new PowerSet<char>(10, 1);
            List<char> strings = new List<char>() { '1', '3', '5', };
            for (int i = 0; i < strings.Count; i++)
            {
                set.Put(strings[i]);
            }

            PowerSet<char> set1 = new PowerSet<char>(10, 1);
            List<char> strings1 = new List<char>() { '1', '5' };
            for (int i = 0; i < strings1.Count; i++)
            {
                set1.Put(strings1[i]);
            }

            bool isSubset = set1.IsSubset(set); // t
            bool isSubset1 = set.IsSubset(set1); // f
        }


    }
}

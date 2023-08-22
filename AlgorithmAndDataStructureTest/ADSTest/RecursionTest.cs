using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using System.IO;

namespace joolTest
{
    [TestClass]
    public class RecursionTest
    {
        [TestMethod]
        public void Test()
        {
            var power = Recursion<int>.Pow(2, 4); //1
            var pow = Recursion<int>.Pow(0, 3);
            LinkedList<int> ints = new LinkedList<int>();
            for (int i = 0; i < 20; i++)
            {
                ints.AddLast(i);
            }
            var length = Recursion<int>.GetLength(ints);

            var sum = Recursion<int>.SumOfNumberDigits(245);

            Assert.AreEqual(true, Recursion<int>.IsPalindrome("123321")); //4
            Assert.AreEqual(false, Recursion<int>.IsPalindrome("123341"));
            Assert.AreEqual(false, Recursion<int>.IsPalindrome("123621"));
            Assert.AreEqual(false, Recursion<int>.IsPalindrome("127621"));
            Assert.AreEqual(true, Recursion<int>.IsPalindrome("1234321"));
            Assert.AreEqual(false, Recursion<int>.IsPalindrome("1234821"));

            List<int> ints1 = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                ints1.Add(i + 234);
            }
            var even = Recursion<int>.GetEvenValues(ints1); //5 печать только чётных значений из списка;

            var evenIndex = Recursion<int>.EvenIndexes(ints1); //6 печать элементов списка с чётными индексами;

            // 7. нахождение второго максимального числа в списке
            // (с учётом, что максимальных может быть несколько, если они равны);
            List<int> nums = new List<int>() { 0, 8, 9, 3, 9, 2, 2 };
            var max = Recursion<int>.Max(nums);
            Assert.AreEqual(9, max);

            // 8. поиск всех файлов в заданном каталоге, включая файлы,
            // расположенные в подкаталогах произвольной вложенности.
            var path = @"C:\Users\Naitoasu\Documents\main";
            var files = Recursion<int>.GetAllFiles(path); //13

        }
    }
}

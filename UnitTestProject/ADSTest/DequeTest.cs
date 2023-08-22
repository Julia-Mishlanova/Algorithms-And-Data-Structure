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
    public class DequeTest
    {
        [TestMethod]
        public void dequeTest()
        {
            Deque<int> dequeTest = new Deque<int>();

            dequeTest.AddFront(5);
            dequeTest.AddFront(4);
            dequeTest.AddFront(3);
            dequeTest.AddFront(2);
            dequeTest.AddFront(1);

            dequeTest.AddTail(44);
            dequeTest.AddTail(33);
            dequeTest.AddTail(22);
            dequeTest.AddTail(11);

            var gog = dequeTest.RemoveFront();
            var gog1 = dequeTest.RemoveFront();
            var gog2 = dequeTest.RemoveFront();

            var bogo = dequeTest.RemoveTail();
            var bogo1 = dequeTest.RemoveTail();
            var bogo2 = dequeTest.RemoveTail();

        }

        [TestMethod]

        public void dequeDumTest()
        {
            DequeDum<int> dequeTest = new DequeDum<int>();

            dequeTest.AddFront(5);
            dequeTest.AddFront(4);
            dequeTest.AddFront(3);

            dequeTest.Size();

            var gog1 = dequeTest.RemoveFront();
            var gog2 = dequeTest.RemoveFront();
            var gog3 = dequeTest.RemoveFront();
            var gog4 = dequeTest.RemoveFront();

            var bogo = dequeTest.RemoveTail();
            var bogo1 = dequeTest.RemoveTail();
            var bogo2 = dequeTest.RemoveTail();

            Assert.AreEqual(true, DequeController.IsPalindrome("123321"));
            Assert.AreEqual(true, DequeController.IsPalindrome("123341"));
            Assert.AreEqual(true, DequeController.IsPalindrome("1234321"));
        }
    }
}

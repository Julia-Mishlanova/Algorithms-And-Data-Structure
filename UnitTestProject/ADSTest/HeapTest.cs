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
    public class HeapTest
    {
        [TestMethod]
        public void Test()
        {
            int[] arr0 = new int[] { 3, 5, 2, 1, 4, 9 };
            Heap heap0 = new Heap();
            heap0.MakeHeap(arr0, 3);
            heap0.Add(7);
            var max0 = heap0.GetMax();

            int[] arr = new int[] { 3, 5, 2, 1, 4, 9 };
            Heap heap = new Heap();
            heap.MakeHeap(arr, 3);
            heap.Add(13); // add new root
            Assert.AreEqual(13, heap.HeapArray[0]);
            var max = heap.GetMax();


            int[] arr1 = new int[] { 3, 9, 6, 10, 4, 5, 8 };
            Heap heap1 = new Heap();
            heap1.MakeHeap(arr1, 3);
            var res = heap1.Add(1);
            Assert.AreEqual(false, res);
            var max1 = heap1.GetMax();


            int[] arr2 = new int[] { 4, 10, 2, 11, 6, 9, 7, 14, 5, 8, 13, 12, 0, 3, 1 };
            Heap heap2 = new Heap();
            heap2.MakeHeap(arr2, 4);
            var max2 = heap2.GetMax();

        }

        [TestMethod]
        public void MakeHeap_MaxInTop()
        {
            Heap heap = new Heap();

            List<int> initial = new List<int>()
            {
                9, 11, 6, 8, 7, 8, 1, 3, 5, 15
            };

            heap.MakeHeap(initial.ToArray(), 4);

            Assert.AreEqual(heap.HeapArray[0], 15);
        }

        [TestMethod]
        public void MakeHeap_CorrectOrder()
        {
            Heap heap = new Heap();

            List<int> initial = new List<int>()
            {
                15, 9, 11, 6, 8, 7, 8, 1, 3, 5
            };

            heap.MakeHeap(initial.ToArray(), 4);

            Assert.AreEqual(heap.HeapArray[0], 15);
            Assert.AreEqual(heap.HeapArray[1], 9);
            Assert.AreEqual(heap.HeapArray[2], 11);
            Assert.AreEqual(heap.HeapArray[3], 6);
            Assert.AreEqual(heap.HeapArray[4], 8);
            Assert.AreEqual(heap.HeapArray[5], 7);
            Assert.AreEqual(heap.HeapArray[6], 8);
            Assert.AreEqual(heap.HeapArray[7], 1);
            Assert.AreEqual(heap.HeapArray[8], 3);
            Assert.AreEqual(heap.HeapArray[9], 5);
        }

        [TestMethod]
        public void Delete_ArrayNull()
        {
            Heap heap = new Heap();

            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_Array_Short1()
        {
            Heap heap = new Heap()
            {
                HeapArray = new int[1]
            };

            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_Array_Short2()
        {
            Heap heap = new Heap()
            {
                HeapArray = new int[1]
            };

            heap.Add(11);

            Assert.AreEqual(heap.GetMax(), 11);
        }

        [TestMethod]
        public void Delete_Array_Short3()
        {
            Heap heap = new Heap()
            {
                HeapArray = new int[2]
            };

            heap.Add(11);

            Assert.AreEqual(heap.GetMax(), 11);
            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_Array_Short4()
        {
            Heap heap = new Heap()
            {
                HeapArray = new int[2]
            };

            heap.Add(11);
            heap.Add(9);

            Assert.AreEqual(heap.GetMax(), 11);
            Assert.AreEqual(heap.GetMax(), 9);
            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_Array_Short5()
        {
            Heap heap = new Heap()
            {
                HeapArray = new int[3]
            };

            heap.Add(11);
            heap.Add(9);
            heap.Add(4);

            Assert.AreEqual(heap.GetMax(), 11);
            Assert.AreEqual(heap.GetMax(), 9);
            Assert.AreEqual(heap.GetMax(), 4);
            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_ArrayEmpty()
        {
            Heap heap = new Heap();

            Assert.AreEqual(heap.GetMax(), (-1));
        }

        [TestMethod]
        public void Delete_OnlyRoot()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[] { 20 }, 1);

            Assert.AreEqual(heap.GetMax(), 20);
            Assert.AreEqual(heap.HeapArray[heap.HeapArray.Length - 1], 0);
        }

        [TestMethod]
        public void Delete_Partly()
        {
            Heap heap = new Heap();
            var arr = new int[9];
            heap.MakeHeap(arr, 4);

            heap.Add(15);
            heap.Add(9);
            heap.Add(11);
            heap.Add(6);
            heap.Add(8);
            heap.Add(7);
            heap.Add(1);
            heap.Add(3);
            heap.Add(5);

            Assert.AreEqual(heap.GetMax(), (15));
            Assert.AreEqual(heap.HeapArray[0], (11));
            Assert.AreEqual(heap.HeapArray[1], (9));
            Assert.AreEqual(heap.HeapArray[2], (8));
            Assert.AreEqual(heap.HeapArray[3], (6));
            Assert.AreEqual(heap.HeapArray[5], (7));
            Assert.AreEqual(heap.HeapArray[6], (5));
            Assert.AreEqual(heap.HeapArray[8], (3));
        }


        [TestMethod]
        public void Add_EmptyAndFillAll_True()
        {
            Heap heap = new Heap();
            {
                heap.HeapArray = new int[3];
            }

            Assert.IsTrue(heap.Add(11));
            Assert.AreEqual(heap.HeapArray[0], (11));
            Assert.IsTrue(heap.Add(9));
            Assert.AreEqual(heap.HeapArray[1], (9));
            Assert.IsTrue(heap.Add(4));
            Assert.AreEqual(heap.HeapArray[2], (4));
        }


    }
}

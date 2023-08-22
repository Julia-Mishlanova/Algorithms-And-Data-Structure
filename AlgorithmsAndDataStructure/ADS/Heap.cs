using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class Heap
    {
        public int[] HeapArray;

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            if (a.Length == 0) return;

            int length = CalculateSize(depth);
            int[] arr = new int[length];
            Array.Copy(a, 0, arr, 0, a.Length);

            bool isHeapify = false;
            while (!isHeapify)
            {
                for (int i = 0; i < length; i++)
                {
                    Heapify(ref arr, i);
                }
                isHeapify = IsHeapify(arr);
            }

            HeapArray = arr;
        }

        private bool IsHeapify(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var leftChild = 2 * i + 1;
                var rightChild = 2 * i + 2;

                if (leftChild < arr.Length
                 || rightChild < arr.Length)
                {
                    if (arr[i] < arr[leftChild]
                     || arr[i] < arr[rightChild]) return false;
                }
            }
            return true;
        }
        private void Heapify(ref int[] array, int i)
        {
            var largest = i;
            var leftChild = 2 * i + 1;
            var rightChild = 2 * i + 2;

            if (leftChild < array.Length)
            {
                if (array[leftChild] > array[largest])
                {
                    largest = leftChild;
                }
            }
            else
            {
                largest = i;
            }

            if (rightChild < array.Length)
            {
                if (array[rightChild] > array[largest])
                {
                    largest = rightChild;
                }
            }

            if (largest != i)
            {
                var buff = array[i];
                array[i] = array[largest];
                array[largest] = buff;
            }
        }

        private static int CalculateSize(int depth)
        {
            int size = 0;
            int buff = 1;
            for (int i = 0; i < depth - 1; i++)
            {
                var sum = buff += buff;
                size += sum;
            }
            return size + 1;
        }

        public int GetMax()
        {
            if (HeapArray == null) return -1;
            if (HeapArray.FirstOrDefault() == 0) return -1;

            int max = HeapArray[0];
            HeapArray[0] = 0;

            for (int i = 0; i < HeapArray.Length - 1; i++)
            {
                var buff = HeapArray[i];
                HeapArray[i] = HeapArray[i + 1];
                HeapArray[i + 1] = buff;
            }

            return max;
        }

        public bool Add(int key)
        {
            if (HeapArray == null) return false;
            if (HeapArray.Length == 1 && HeapArray.FirstOrDefault() != 0) return false;

            if (HeapArray[0] == 0)
            {
                HeapArray[0] = key;
                return true;
            }

            bool wasAdded = false;
            int ind = 0;

            for (int i = HeapArray.Length - 1; i > 0; i--)
            {
                if (HeapArray[i] == 0 && HeapArray[i - 1] != 0)
                {
                    HeapArray[i] = key;
                    ind = i;
                    wasAdded = true;
                    break;
                }
            }
            if (wasAdded == false) return false;

            bool isHeapify = false;
            while (!isHeapify)
            {
                if (HeapArray[ind - 1] < HeapArray[ind])
                {
                    var buff = HeapArray[ind - 1];
                    HeapArray[ind - 1] = HeapArray[ind];
                    HeapArray[ind] = buff;
                    ind--;

                    if (ind <= 0) break;
                }
                else if (HeapArray[ind - 1] > HeapArray[ind])
                {
                    isHeapify = true;
                }
            }
            return wasAdded;
        }
    }
}


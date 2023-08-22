using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;
        public Dictionary<String, T> cache = new Dictionary<string, T>();

        public NativeCache(int Size)
        {
            size = Size;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }
        public int HashFun(string key)
        {
            int index = 0;
            foreach (var item in key)
            {
                index += ((byte)item);
            }
            return index % size;
        }
        public bool IsKey(string key)
        {
            if (key == null) return false;

            int index = HashFun(key);
            int CountPassElements = 0;
            int i = index;


            while (slots[i] != key)
            {
                i++;

                if (CountPassElements >= size)
                {
                    i = -1;
                    break;
                }
                if (i > size - 1) i = 0;
                CountPassElements++;
            }
            return i != -1;
        }
        public int FindLessHits()
        {
            int min = int.MaxValue;
            int indexOfMin = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (min > hits[i])
                {
                    min = hits[i];
                    indexOfMin = i;
                }
            }
            return indexOfMin;
        }
        public void Put(string key, T value)
        {
            if (key == null) return;
            if (size <= 0) return;
            if (IsKey(key) == true) return;

            cache.Add(key, value);

            var index = this.HashFun(key);

            if (slots[index] != null)
            {
                int i = index;
                int CountPassElements = 0;
                while (slots[i] != null)
                {
                    i++;
                    CountPassElements++;

                    if (CountPassElements > size)
                    {
                        var newIndex = FindLessHits();
                        cache.Remove(slots[newIndex]);

                        slots[newIndex] = key;
                        values[newIndex] = value;
                        hits[newIndex]++;
                        return;
                    }
                    if (i >= size - 1) i = 0;
                }
                index = i;
            }
            if (index != -1)
            {
                slots[index] = key;
                values[index] = value;
                hits[index]++;
            }
        }
        public T Get(string key)
        {
            if (this.IsKey(key))
            {
                var index = this.HashFun(key);
                int CountPassElements = 0;
                int i = index;

                while (slots[i] != key)
                {
                    i++;
                    CountPassElements++;

                    if (CountPassElements >= size)
                    {
                        i = -1;
                        break;
                    }
                    if (i > size - 1) i = 0;
                }
                if (i != -1)
                {
                    hits[i]++;
                    return values[i];
                }
            }
            return default;
        }
    }
}

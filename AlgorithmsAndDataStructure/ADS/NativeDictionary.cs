using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        // step++

        public NativeDictionary(int size)
        {
            this.size = size;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int chVal = 0;
            for (int i = 0; i < key.Length; i++)
            {
                chVal += key[i];
            }
            return size == 0 ? 0 : chVal % size;
        }

        public bool ContainsKey(string key)
        {
            int index = HashFun(key);
            int CountPassElements = 0;
            int i = index;

            while (slots[i] != key)
            {
                i++;
                CountPassElements++;
                if (CountPassElements > size)
                {
                    i = -1;
                    break;
                }
                if (i >= size - 1) i = 0;
            }
            return i != -1;
        }

        public void Put(string key, T inputValue)
        {
            if (size <= 0) return;
            if (ContainsKey(key) == true) return;

            var index = HashFun(key);

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
                        i = -1;
                        break;
                    }
                    if (i >= size - 1) i = 0;
                }
                index = i;
            }
            if (index != -1)
            {
                slots[index] = key;
                values[index] = inputValue;
            }
        }

        public T Get(string key)
        {
            if (ContainsKey(key))
            {
                int index = HashFun(key);
                int CountPassElements = 0;
                int i = index;

                while (slots[i] != key)
                {
                    i++;
                    CountPassElements++;
                    if (CountPassElements > size)
                    {
                        i = -1;
                        break;
                    }
                    if (i >= size - 1) i = 0;
                }
                return values[i];
            }
            return default;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp_ADS
{
    public class HashTable<T>
    {
        public int size;
        public int step;
        public T[] slots;

        public HashTable()
        { }
        public HashTable(int sz, int stp)
        {
            size = sz;
            slots = new T[size];
            step = 1;
        }

        public int HashFun(T value)
        {
            if (value == null) return -1;

            string val = value.ToString();
            int chVal = 0;
            for (int i = 0; i < val.Length; i++)
            {
                chVal += val[i];
            }
            return size == 0 ? 0 : chVal % size;
        }

        public int SeekSlot(T value)
        {
            if (step <= 0) return -1;

            int i = HashFun(value);
            int CountPassElements = 0;
            while (!EqualityComparer<T>.Default.Equals(slots[i], default))
            {
                i += step;
                CountPassElements++;
                if (CountPassElements > size) return -1;
                if (i > size - 1) i = 0;
            }
            return i;
        }

        public int Put(T value)
        {
            if (size <= 0) return -1;
            if (Find(value) != -1) return -1;

            int index = HashFun(value);

            if (slots[index] != null)
            {
                index = SeekSlot(value);
            }
            if (index != -1) slots[index] = value;

            return index;
        }

        public int Find(T value)
        {
            int index = HashFun(value);

            if (index >= size) return -1;
            if (index < 0) return -1;

            int CountPassElements = 0;
            string slot = slots[index] == null ? string.Empty : slots[index].ToString();
            string val = value.ToString();
            while (slot != val)
            {
                index += step;
                CountPassElements++;
                if (CountPassElements > size) return -1;
                if (index > size - 1) index = 0;

                slot = slots[index] == null ? string.Empty : slots[index].ToString();
            }
            return index;
        }
    }
}

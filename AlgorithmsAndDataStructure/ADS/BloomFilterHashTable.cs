using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class BloomFilterHashTable
    {
        public int filter_len;
        public HashTable<bool> table;

        public BloomFilterHashTable(int f_len)
        {
            filter_len = f_len;
            table = new HashTable<bool>(filter_len, 1);
        }

        public int Hash1(string str1)
        {
            if (str1 == null) return -1;

            var result = 0;
            foreach (var item in str1)
            {
                result = (result * 17 + (byte)item) % filter_len;
            }
            return result;
            //17
        }
        public int Hash2(string str1)
        {
            if (str1 == null) return -1;

            var result = 0;
            foreach (var item in str1)
            {
                result = (result * 223 + (byte)item) % filter_len;
            }
            return result;
            //223
        }
        public void Add(string str1)
        {
            if (str1 == null) return;

            var h1 = Hash1(str1);
            var h2 = Hash2(str1);

            table.slots[h1] = true;
            table.slots[h2] = true;
        }
        public bool IsValue(string str1)
        {
            if (str1 == null) return false;

            var h1 = Hash1(str1);
            var h2 = Hash2(str1);

            var val = table.slots[h1];
            var val1 = table.slots[h2];

            return (val == true && val1 == true) ? true : false;

        }
    }
}

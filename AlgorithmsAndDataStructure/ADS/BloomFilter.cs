using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class ArrayOfBits
    {
        public int value = 0;
        public ArrayOfBits() { }

        public void SetValue(int bit)
        {
            value |= bit;
        }
        public bool getValue(int bit)
        {
            bool bitExists = true;
            var oneBit = 1;

            var valueShift = value >> bit;
            var result = valueShift & oneBit; 

            return (result == 1) ? bitExists : !bitExists;
        }
    }
    public class BloomFilter
    {
        public int filter_len;
        public ArrayOfBits arrayOfBits;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            arrayOfBits = new ArrayOfBits();
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
        }
        public void Add(string str1)
        {
            if (str1 == null) return;

            var h1 = Hash1(str1);
            var h2 = Hash2(str1);

            var val1 = 1;
            val1 <<= h1;

            var val2 = 1;
            val2 <<= h2;

            arrayOfBits.SetValue(val1);
            arrayOfBits.SetValue(val2);
        }
        public bool IsValue(string str1)
        {
            if (str1 == null) return false;

            var h1 = Hash1(str1);
            var h2 = Hash2(str1);

            var val1 = arrayOfBits.getValue(h1);
            var val2 = arrayOfBits.getValue(h2);

            return (val1 == true && val2 == true) ? true : false;
        }
    }
}

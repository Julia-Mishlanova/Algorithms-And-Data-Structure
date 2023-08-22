using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class DynArray<T>
    {
        public T[] array;
        public int count;
        private int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }
        public void MakeArray(int new_capacity)
        {
            if (new_capacity < 16)
            {
                new_capacity = 16;
            }
            capacity = new_capacity;
            array = new T[capacity];

        }
        
        public T GetItem(int index)
        {
            if (index < capacity)
            {
                return array[index];
            }
            throw new ArgumentOutOfRangeException();

        }
        public void Append(T itm)
        {
            T[] temp = array;

            if (count == capacity)
            {
                capacity *= 2;
                temp = new T[capacity];

                int i = 0;
                while (i < count)
                {
                    temp[i] = array[i];
                    i++;
                }
                temp[i] = itm;
                count++;
                array = temp;
            }
            else
            {
                temp[count] = itm;
                count++;
                array = temp;
            }

        }
        public void Insert(T itm, int index)
        {
            if (count == capacity)
            {
                capacity *= 2;
            }
            T[] temp = new T[capacity];

            if (index < capacity)
            {
                for (int i = 0; i < index; i++)
                {
                    temp[i] = array[i];
                }

                temp[index] = itm;

                for (int i = index; i < count; i++)
                {
                    temp[i + 1] = array[i];
                }

                count++;
                array = temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

        }
        public void Remove(int index)
        {
            T[] temp = array;

            if (index < capacity && index >= 0)
            {

                for (int i = index; i < count + 1; i++)
                {
                    temp[i] = temp[i + 1];
                }
                count--;

                if (capacity / 2 > count)
                {
                    capacity = (int)Math.Round(capacity / 1.5);
                    array = new T[capacity];
                    for (int i = 0; i < count; i++)
                    {
                        array[i] = temp[i];
                    }
                }
                else
                {
                    array = temp;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}

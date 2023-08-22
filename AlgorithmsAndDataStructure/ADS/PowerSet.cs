using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class PowerSet<T> : HashTable<T>
    {
        public PowerSet(int sz, int stp) : base()
        {
            size = sz;
            step = stp;
            slots = new T[size];
        }
        public PowerSet() : base()
        {
            size = 200;
            step = 1;
            slots = new T[size];
        }
        public void Put(T value)
        {
            if (size <= 0) return;
            if (Find(value) != -1) return;

            int index = HashFun(value);
            if (index == -1 || index > size) return;
            if (!EqualityComparer<T>.Default.Equals(slots[index], default))
            {
                index = SeekSlot(value);
            }
            if (index > -1)
            {
                slots[index] = value;
            }
        }
        public int Size()
        {
            int count = 0;
            foreach (var slot in slots)
            {
                if (EqualityComparer<T>.Default.Equals(slot, default)) continue;
                count++;
            }
            return count;
        }
        public bool Get(T value)
        {
            int index = Find(value);

            if (index == -1) return false;
            else return true;
        }
        public bool Remove(T value)
        {
            int index = Find(value);

            if (index == -1)
            {
                return false;
            }
            else
            {
                slots[index] = default;
                return true;
            }
        }
        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            var largerSet = new PowerSet<T>(0, step);
            var smallerSet = new PowerSet<T>(0, step);

            if (size > set2.size)
            {
                largerSet.slots = slots;
                largerSet.size = size;
                smallerSet = set2;
            }
            if (size <= set2.size)
            {
                largerSet = set2;
                smallerSet.slots = slots;
                smallerSet.size = size;
            }

            var setOfIntersections = new PowerSet<T>(largerSet.size, step);
            for (int i = 0; i < largerSet.size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(largerSet.slots[i], default)) continue;

                if (smallerSet.Find(largerSet.slots[i]) != -1) setOfIntersections.Put(largerSet.slots[i]);
            }
            return setOfIntersections;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            var union = new PowerSet<T>(size + set2.size, step);

            for (int i = 0; i < set2.size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(set2.slots[i], default)) continue;
                union.Put(set2.slots[i]);
            }

            for (int i = 0; i < size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(slots[i], default)) continue;
                union.Put(slots[i]);
            }
            return union;
        }
        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            var largerSet = new PowerSet<T>(0, step);
            var smallerSet = new PowerSet<T>(0, step);

            if (size > set2.size)
            {
                largerSet.slots = slots;
                largerSet.size = size;
                smallerSet = set2;
            }
            if (size <= set2.size)
            {
                largerSet = set2;
                smallerSet.slots = slots;
                smallerSet.size = size;
            }

            var setOfDifference = new PowerSet<T>(largerSet.size, step);
            for (int i = 0; i < largerSet.size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(largerSet.slots[i], default)) continue;

                if (smallerSet.Find(largerSet.slots[i]) == -1) setOfDifference.Put(largerSet.slots[i]);
            }
            return setOfDifference;
        }
        
        public bool IsSubset(PowerSet<T> set2)
        {
            for (int i = 0; i < size; i++)
            {
                if (EqualityComparer<T>.Default.Equals(slots[i], default)) continue;

                if (set2.Find(slots[i]) == -1) return false;
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class Queue<T>
    {
        private List<T> queue = new List<T>();

        public Queue()
        {
        }

        public void Enqueue(T item)
        {
            queue.Add(item);
        }

        public T Dequeue()
        {
            if (queue.Count == 0) return default;

            var buff = queue[0];
            queue.Remove(queue[0]);
            return buff;
        }

        public int Size()
        {
            return queue.Count;
        }
    }

    public class QueueController<T>
    {
        public static void CircleShiftQueue<T>(Queue<T> queue, int steps)
        {
            int i = 0;
            while (i < steps)
            {
                var buff = queue.Dequeue();
                queue.Enqueue(buff);
                i++;
            }
        }
    }

}

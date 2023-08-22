using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp_ADS
{
    public class TwoStacksQueue<T>
    {
        readonly System.Collections.Generic.Stack<T> firstStack = new System.Collections.Generic.Stack<T>();
        readonly System.Collections.Generic.Stack<T> secondStack = new System.Collections.Generic.Stack<T>();
        public TwoStacksQueue()
        {
            firstStack = new System.Collections.Generic.Stack<T>();
            secondStack = new System.Collections.Generic.Stack<T>();
        }

        public void Enqueue(T item)
        {
            while (secondStack.Count != 0)
            {
                firstStack.Push(secondStack.Pop());
            }
            firstStack.Push(item);

            while (firstStack.Count != 0)
            {
                secondStack.Push(firstStack.Pop());
            }
        }

        public T Dequeue()
        {
            if (secondStack.Count == 0) return default;
            return secondStack.Pop();
        }

        public int Size()
        {
            return secondStack.Count;
        }
    }
}
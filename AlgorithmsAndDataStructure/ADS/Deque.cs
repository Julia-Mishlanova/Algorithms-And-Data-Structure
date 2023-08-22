using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class DequeNode<T>
    {
        public T value;
        public DequeNode<T> next, prev;

        public DequeNode(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
        public DequeNode()
        {
        }
    }
    public class Deque<T>
    {
        public DequeNode<T> head;
        public DequeNode<T> tail;

        public Deque()
        {
            head = null;
            tail = null;
        }

        public void AddFront(T item)
        {
            DequeNode<T> nodeToInsert = new DequeNode<T>(item);
            if (head != null)
            {
                var n = head;

                head = nodeToInsert;
                head.next = n;
                head.next.prev = nodeToInsert;
            }
            else { head = nodeToInsert; }

            if (tail == null)
            {
                tail = nodeToInsert;
            }
        }

        public void AddTail(T item)
        {
            DequeNode<T> nodeToInsert = new DequeNode<T>(item);

            if (head == null)
            {
                head = nodeToInsert;
            }
            else
            {
                tail.next = nodeToInsert;
                nodeToInsert.prev = tail;
            }
            tail = nodeToInsert;
        }

        public T RemoveFront()
        {
            var currNode = head;
            head = currNode.next;
            head.prev = null;

            return currNode.value;
        }

        public T RemoveTail()
        {
            var buff = tail;
            tail.prev.next = null;
            tail = tail.prev;

            return buff.value;
        }

        public int Size()
        {
            int count = 0;
            var currNode = head;

            while (currNode != null)
            {
                count++;
                currNode = currNode.next;
            }
            return count;
        }
    }

    public class DequeDumNode<T> : DequeNode<T>
    {
        public DequeDumNode(T _value) : base(_value) { }
        public DequeDumNode() : base() { }
    }
    public class DequeDum<T>
    {
        public DequeDumNode<T> head;
        public DequeDumNode<T> tail;

        public DequeDum()
        {
            head = new DequeDumNode<T>();
            tail = new DequeDumNode<T>();

            head.next = tail;
            head.prev = tail;

            tail.prev = head;
            tail.next = head;
        }

        public void AddFront(T item)
        {
            DequeNode<T> nodeToInsert = new DequeNode<T>(item);

            if (!head.next.Equals(tail))
            {
                var buff = head.next;
                head.next = nodeToInsert;
                buff.prev = nodeToInsert;
                nodeToInsert.prev = head;
                nodeToInsert.next = buff;
            }
            else
            {
                head.next = nodeToInsert;
                tail.prev = nodeToInsert;
                nodeToInsert.prev = head;
                nodeToInsert.next = tail;
            }
        }

        public void AddTail(T item)
        {
            DequeNode<T> nodeToInsert = new DequeNode<T>(item);

            if (head.next is DequeDumNode<T>)
            {
                head.next = nodeToInsert;
                tail.prev = nodeToInsert;
                nodeToInsert.prev = head;
                nodeToInsert.next = tail;
            }
            else
            {
                nodeToInsert.prev = tail.prev;
                nodeToInsert.prev.next = nodeToInsert;
                nodeToInsert.next = tail;
                tail.prev = nodeToInsert;
            }
        }

        public T RemoveFront()
        {
            var result = head.next;
            if (!head.next.Equals(tail))
            {
                var currNode = head.next;
                currNode.prev.next = currNode.next;
                currNode.next.prev = currNode.prev;

                return result.value;
            }
            return default;
        }

        public T RemoveTail()
        {
            var result = tail.prev;
            if (!tail.prev.Equals(head))
            {
                var currNode = tail.prev;
                currNode.prev.next = currNode.next;
                currNode.next.prev = currNode.prev;

                return result.value;
            }
            return default;
        }

        public int Size()
        {
            var currNode = head.next;
            int count = 0;
            while (!currNode.Equals(tail))
            {
                count++;
                currNode = currNode.next;
            }
            return count;
        }
    }

    public static class DequeController
    {
        public static bool IsPalindrome(string word)
        {
            DequeDum<int> deque = new DequeDum<int>();

            foreach (var letter in word)
            {
                deque.AddTail(letter);
            }

            var currFront = deque.head.next;
            var currTail = deque.tail.prev;

            var count = 0;
            while (count < word.Length)
            {
                if (currFront.value != currTail.value) return false;

                currFront = currFront.next;
                currTail = currTail.prev;

                count += 2;
            }
            return true;
        }
    }

}

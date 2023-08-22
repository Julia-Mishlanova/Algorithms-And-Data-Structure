using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp_ADS
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }

        public Node() { }
    }

    public class DumNode<T> : Node<T>
    {
        public DumNode(T _value) : base(_value) { }
        public DumNode() : base() { }
    }

    public class OrderedList<T>
    {
        public DumNode<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = new DumNode<T>();
            tail = new DumNode<T>();

            head.next = tail;
            head.prev = tail;

            tail.prev = head;
            tail.next = head;

            _ascending = asc;
        }
        // v1 = v2 0, v1>v2 1, иначе -1
        public int Compare(T v1, T v2)
        {
            if (v1.GetType() == typeof(int))
            {
                int num1 = int.Parse(v1.ToString());
                int num2 = int.Parse(v2.ToString());

                if (num1 == num2) return 0;
                else if (num1 > num2) return 1;
                else return -1;
            }
            else if (v1.GetType() == typeof(bool))
            {
                bool bl1 = bool.Parse(v1.ToString());
                bool bl2 = bool.Parse(v2.ToString());

                if (bl1 == false && bl2 == false || bl1 == true && bl2 == true) return 0;
                if (bl1 == true && bl2 == false) return 1;
                if (bl1 == false && bl2 == true) return -1;
            }
            else
            {
                string str1 = v1.ToString();
                string str2 = v2.ToString();

                return CompareStrings(str1, str2);
            }
            return 0;
        }

        public void Add(T value)
        {
            Node<T> nodeToInsert = new Node<T>(value);
            var currNode = head.next;

            if (currNode.Equals(tail))
            {
                head.next = nodeToInsert;
                tail.prev = nodeToInsert;
                nodeToInsert.prev = head;
                nodeToInsert.next = tail;
            }

            while (!currNode.Equals(tail))
            {
                if (Compare(currNode.value, value) == 0)
                {
                    var buff = currNode.prev;

                    currNode.prev = nodeToInsert;
                    nodeToInsert.next = currNode;
                    nodeToInsert.prev = buff;
                    buff.next = nodeToInsert;

                    break;
                }
                if (ComparingValuesForAscendingList(value, currNode) || ComparingValuesForDescendingList(value, currNode))
                {
                    var buff = currNode.prev;

                    currNode.prev = nodeToInsert;
                    nodeToInsert.next = currNode;
                    nodeToInsert.prev = buff;
                    buff.next = nodeToInsert;

                    break;
                }
                if (InAscendingListValueGreaterThanTail(value) || InDescendingListValueLessThanTail(value))
                {
                    if (head.next is DumNode<T>)
                    {
                        head.next = nodeToInsert;
                        tail.prev = nodeToInsert;
                        nodeToInsert.prev = head;
                        nodeToInsert.next = tail;

                        break;
                    }
                    else
                    {
                        nodeToInsert.prev = tail.prev;
                        nodeToInsert.prev.next = nodeToInsert;
                        tail.prev = nodeToInsert;
                        nodeToInsert.next = tail;

                        break;
                    }
                }
                if (InAscendingListValueLessThanHead(value) || InDescendingListValueGreaterThanTail(value))
                {
                    if (!currNode.Equals(tail))
                    {
                        var n = currNode;
                        head.next = nodeToInsert;
                        n.prev = nodeToInsert;
                        nodeToInsert.prev = head;
                        nodeToInsert.next = n;

                        break;
                    }
                    else
                    {
                        head.next = nodeToInsert;
                        tail.prev = nodeToInsert;
                        nodeToInsert.prev = head;
                        nodeToInsert.next = tail;

                        break;
                    }
                }
                currNode = currNode.next;
            }
        }
        private bool InDescendingListValueGreaterThanTail(T value)
        {
            return _ascending == false && Compare(value, head.next.value) == 1;
        }
        private bool InAscendingListValueLessThanHead(T value)
        {
            return _ascending == true && Compare(value, head.next.value) == -1;
        }
        private bool InDescendingListValueLessThanTail(T value)
        {
            return _ascending == false && Compare(value, tail.prev.value) == -1;
        }
        private bool InAscendingListValueGreaterThanTail(T value)
        {
            return _ascending == true && Compare(value, tail.prev.value) == 1;
        }
        private bool ComparingValuesForDescendingList(T value, Node<T> currNode)
        {
            return _ascending == false && currNode.prev.value != null && Compare(currNode.prev.value, value) == 1 && Compare(currNode.value, value) == -1;
        }
        private bool ComparingValuesForAscendingList(T value, Node<T> currNode)
        {
            return _ascending == true && currNode.prev.value != null && Compare(currNode.prev.value, value) == -1 && Compare(currNode.value, value) == 1;
        }

        public Node<T> Find(T val)
        {
            List<Node<T>> nodes = GetAll();
            return BinarySearch(nodes, val);
        }

        public void Delete(T ValueToDelete)
        {
            if (_ascending == true)
            {
                if (Compare(ValueToDelete, head.next.value) != -1 &&
                    Compare(ValueToDelete, tail.prev.value) != 1)
                {
                    var n = Find(ValueToDelete);
                    if (n.next != default)
                    {
                        n.prev.next = n.next;
                        n.next.prev = n.prev;
                    }
                }
            }
            // v1 = v2 0, v1>v2 1, иначе -1
            if (_ascending == false)
            {
                if (Compare(ValueToDelete, head.next.value) != 1 &&
                    Compare(ValueToDelete, tail.prev.value) != -1)
                {
                    var n = Find(ValueToDelete);
                    if (n.next != default)
                    {
                        n.prev.next = n.next;
                        n.next.prev = n.prev;
                    }
                }
            }
        }

        public void Clear(bool asc)
        {
            _ascending = asc;

            head.next = tail;
            head.prev = tail;

            tail.prev = head;
            tail.next = head;
        }

        public int Count()
        {
            int count = 0;
            var currNode = head.next;

            while (!currNode.Equals(tail))
            {
                count++;
                currNode = currNode.next;
            }
            return count;
        }

        List<Node<T>> GetAll()
        {
            List<Node<T>> listOfNodes = new List<Node<T>>();
            var currNode = head.next;

            while (!currNode.Equals(tail))
            {
                listOfNodes.Add(currNode);
                currNode = currNode.next;
            }
            return listOfNodes;
        }

        private static int CompareStrings(string str1, string str2)
        {
            if (str1.Equals(str2)) return 0;

            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
            for (int i = 0; i < letters.Length; i++)
            {
                alphabet.Add(letters[i], i + 1);
            }

            int length = 0;
            if (str1.Length <= str2.Length) length = str1.Length;
            else length = str2.Length;

            for (int i = 0; i < length; i++)
            {
                if (!alphabet.ContainsKey(str1[i]) || !alphabet.ContainsKey(str2[i])) continue;

                if (alphabet[str1[i]] == alphabet[str2[i]]) continue;
                if (alphabet[str1[i]] > alphabet[str2[i]]) return 1;
                else return -1;
            }

            if (str1.Length > str2.Length) return 1;
            if (str1.Length < str2.Length) return -1;

            return 0;
        }

        private Node<T> BinarySearch(List<Node<T>> inputedList, T inputedValue)
        {
            if (_ascending == false) inputedList.Reverse();

            int low = 0;
            int high = inputedList.Count - 1;
            int middle = 0;

            while (low <= high)
            {
                middle = (low + high) / 2;

                if (Compare(inputedList[middle].value, inputedValue) == 0)
                {
                    return inputedList[middle];
                }
                else if (Compare(inputedList[middle].value, inputedValue) == 1) // >
                {
                    high = middle - 1;
                }
                else // <
                {
                    low = middle + 1;
                }
            }
            return new Node<T>();
        }
    }
}

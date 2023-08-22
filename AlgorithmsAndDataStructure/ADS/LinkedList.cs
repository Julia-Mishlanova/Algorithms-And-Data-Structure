using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp_ADS
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }
    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }
        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
            }
            else
            {
                tail.next = _item;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            var currNode = head;

            while (currNode != null)
            {
                if (currNode.value == _value)
                {
                    return currNode;
                }
                currNode = currNode.next;
            }
            return null;
        }

        public List<Node> FindAll(int _value)
        {
            var specificNodes = new List<Node>();
            var currNode = head;

            while (currNode != null)
            {
                if (currNode.value == _value)
                {
                    specificNodes.Add(currNode);
                }
                currNode = currNode.next;
            }
            return specificNodes;
        }

        public bool Remove(int _value)
        {
            var currNode = head;
            Node prevNode = head;

            if (head == null) return false;

            while (currNode != null || prevNode.next != null)
            {
                if (currNode.value == _value && currNode != head)
                {
                    prevNode.next = currNode.next;
                    if (currNode.next == null) tail = prevNode;

                    return true;
                }
                if (currNode.value == _value && currNode == head)
                {
                    head = currNode.next;

                    return true;
                }
                prevNode = currNode;
                currNode = currNode.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            var currNode = head;
            Node prevNode = null;

            while (currNode != null)
            {
                if (currNode.value == _value)
                {
                    if (prevNode != null)
                    {

                        prevNode.next = currNode.next;
                        if (currNode.next == null)
                        {

                            tail = prevNode;
                        }

                    }
                    else
                    {
                        head = currNode.next;
                        if (head == null) tail = null;
                    }
                    currNode = currNode.next;
                    continue;
                }
                prevNode = currNode;
                currNode = currNode.next;
            }


        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
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
        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            var currNode = head;
            Node prevNode = null;

            if (_nodeAfter == tail)
            {
                tail = _nodeToInsert;
            }

            while (currNode != null)
            {
                if (_nodeToInsert == null) break;

                prevNode = currNode;
                currNode = currNode.next;

                if (prevNode.Equals(_nodeAfter))
                {
                    prevNode.next = _nodeToInsert;
                    break;
                }
            }
            if (_nodeAfter == null)
            {
                if (head != null)
                {
                    var n = head;
                    head = _nodeToInsert;
                    head.next = n;
                }
                else { head = _nodeToInsert; }

                if (tail == null)
                {
                    tail = _nodeToInsert;
                }


            }
            else if (_nodeAfter != null && _nodeToInsert != null)
            {
                _nodeToInsert.next = currNode;
            }

        }


    }

    public class LinkedListController
    {
        public Node head;
        public Node tail;

        public LinkedListController()
        {
            head = null;
            tail = null;
        }
        public static LinkedList SumTwoLinkedLists(LinkedList testList, LinkedList testList2)
        {
            var currNode = testList.head;
            var currNode2 = testList2.head;
            LinkedList sum = new LinkedList();

            if (testList.Count() == testList2.Count())
            {
                while (currNode != null)
                {
                    int value = (currNode.value + currNode2.value);
                    var newNode = new Node(value);
                    sum.AddInTail(newNode);

                    currNode = currNode.next;
                    currNode2 = currNode2.next;
                }
                return sum;
            }
            return null;
        }

        public static bool TwoLinkedListsAreEqual(LinkedList testList, LinkedList testList2)
        {
            var currNode = testList.head;
            var currNode2 = testList2.head;

            while (currNode != null)
            {
                if (currNode.value != currNode2.value)
                {
                    return false;
                }
                currNode = currNode.next;
                currNode2 = currNode2.next;
            }
            return true;
        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;

public class Node
{
    public int value;
    public Node next, prev;

    public Node()
    { }
    public Node(int _value)
    {
        value = _value;
        next = null;
        prev = null;
    }

}

public class LinkedList2
{
    public Node head;
    public Node tail;

    public LinkedList2()
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
            _item.prev = tail;
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
        if (head == null) return false;

        var currNode = head;

        while (currNode != null)
        {
            if (currNode.value == _value)
            {
                if (currNode.value == head.value)
                {
                    head = currNode.next;
                    head.prev = null;
                    return true;
                }

                currNode.prev.next = currNode.next;
                if (currNode.next != null)
                {
                    currNode.next.prev = currNode.prev;
                }

                return true;
            }
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
                    if (currNode.next != null)
                    {
                        currNode.next.prev = currNode.prev;
                        prevNode.next = currNode.next;
                    }
                    else
                    {
                        prevNode.next = null;
                        tail = prevNode;
                        break;
                    }
                }
                else
                {
                    head = currNode.next;
                    head.prev = null;
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
                _nodeToInsert.prev = prevNode;
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
                head.next.prev = _nodeToInsert;
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
            if (currNode != null)
            {
                currNode.prev = _nodeToInsert;
            }
        }
    }

    public class DNode : Node
    {
        public DNode(int _value) : base(_value) { }
        public DNode() : base() { }
    }
    public class DLinkedList
    {
        public DNode head;
        public DNode tail;

        public DLinkedList()
        {
            head = new DNode();
            tail = new DNode();

            head.next = tail;
            head.prev = tail;

            tail.prev = head;
            tail.next = head;
        }
        public void AddInTail(Node _item)
        {
            if (head.next is DNode)
            {
                head.next = _item;
                tail.prev = _item;
                _item.prev = head;
                _item.next = tail;
            }
            else
            {
                _item.prev = tail.prev;
                _item.prev.next = _item;
                tail.prev = _item;
                _item.next = tail;
            }
        }

        public Node Find(int _value)
        {
            var currNode = head.next;

            while (!currNode.Equals(tail))
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
            List<Node> specificNodes = new List<Node>();
            var currNode = head.next;

            while (!currNode.Equals(tail))
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
            var currNode = head.next;

            while (!currNode.Equals(tail))
            {
                if (currNode.value == _value)
                {
                    currNode.prev.next = currNode.next;
                    currNode.next.prev = currNode.prev;

                    return true;
                }
                currNode = currNode.next;
            }
            return false;
        }

        public void RemoveAll(int _value)
        {
            var currNode = head.next;

            while (!currNode.Equals(tail))
            {
                if (currNode.value == _value)
                {
                    currNode.prev.next = currNode.next;
                    currNode.next.prev = currNode.prev;
                }
                currNode = currNode.next;
            }
        }

        public void Clear()
        {
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

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            var currNode = head.next;

            if (_nodeToInsert != null)
            {
                if (_nodeAfter == null)
                {
                    if (!currNode.Equals(tail))
                    {
                        var n = currNode;
                        head.next = _nodeToInsert;
                        n.prev = _nodeToInsert;
                        _nodeToInsert.prev = head;
                        _nodeToInsert.next = n;
                    }
                    else
                    {
                        head.next = _nodeToInsert;
                        tail.prev = _nodeToInsert;
                        _nodeToInsert.prev = head;
                        _nodeToInsert.next = tail;
                    }
                }
                else
                {
                    while (!currNode.Equals(tail))
                    {
                        if (currNode.Equals(_nodeAfter))
                        {
                            var buff = currNode.next;

                            currNode.next = _nodeToInsert;
                            _nodeToInsert.prev = currNode;
                            _nodeToInsert.next = buff;
                            buff.prev = _nodeToInsert;

                            break;
                        }
                        currNode = currNode.next;
                    }
                }
            }
        }

    }

    //дальше и так понятно по названию методов
    public static class LinkedList2Controller
    {
        public static LinkedList2 SumTwoLinkedLists(LinkedList2 firstLinkedList, LinkedList2 secondLinkedList)
        {
            var currNode = firstLinkedList.head;
            var currNode2 = secondLinkedList.head;
            LinkedList2 sum = new LinkedList2();

            if (firstLinkedList.Count() == secondLinkedList.Count())
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

        public static bool TwoLinkedListsAreEqual(LinkedList2 firstLinkedList, LinkedList2 secondLinkedList)
        {
            var firstCurrNode = firstLinkedList.head;
            var secondCurrNode = secondLinkedList.head;

            while (firstCurrNode != null)
            {
                if (firstCurrNode.value != secondCurrNode.value)
                {
                    return false;
                }
                firstCurrNode = firstCurrNode.next;
                secondCurrNode = secondCurrNode.next;
            }
            return true;
        }
    }
}


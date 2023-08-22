using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
    public class Stack<T>
    {
        public LinkedList<T> stack = new LinkedList<T>();
        public Stack()
        {
        }

        public int Size()
        {
            return stack.Count;
        }

        public T Pop()
        {
            if (stack == null) return default;

            var last = stack.First;
            stack.Remove(stack.First);
            return last.Value;
        }

        public void Push(T val)
        {
            stack.AddFirst(val);
        }

        public T Peek()
        {
            if (stack == null) return default;
            return stack.First.Value;
        }
    }

    public static class StackController
    {
        public static bool IsBalancedParentheses(string example)
        {
            if (example[0] == ')') return false;

            Stack<char> parentheses = new Stack<char>();

            for (int i = 0; i < example.Length; i++)
            {
                if (example[i] == '(')
                {
                    parentheses.Push(example[i]);
                    continue;
                }
                if (parentheses.Size() == 0) return false;

                parentheses.Pop();
            }
            return parentheses.Size() == 0 ? true : false;
        }

        public static int ReversePolishNotationString(string example)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < example.Length; i++)
            {
                if (char.IsDigit(example[i]))
                {
                    int num = int.Parse(example[i].ToString());
                    stack.Push(num);
                    continue;
                }

                if (example[i] != ' ')
                {
                    var a = stack.Pop();
                    var b = stack.Pop();

                    if (example[i] == '+') stack.Push(b + a);
                    else if (example[i] == '-') stack.Push(b - a);
                    else if (example[i] == '*') stack.Push(b * a);
                    else if (example[i] == '/') stack.Push(b / a);
                }
            }
            return stack.Pop();
        }

        public static int ReversePolishNotation(Stack<char> example)
        {
            Stack<int> stack = new Stack<int>();
            int length = example.Size();

            for (int i = 0; i < length; i++)
            {
                var item = example.Pop();
                if (char.IsDigit(item))
                {
                    int num = int.Parse(item.ToString());
                    stack.Push(num);
                    continue;
                }

                if (item != ' ')
                {
                    var a = stack.Pop();
                    var b = stack.Pop();

                    if (item == '+') stack.Push(b + a);
                    else if (item == '-') stack.Push(b - a);
                    else if (item == '*') stack.Push(b * a);
                    else if (item == '/') stack.Push(b / a);
                }
            }
            return stack.Pop();
        }

    }

}

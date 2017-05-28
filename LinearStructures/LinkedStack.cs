using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    public class LinkedStack<T>
    {
        private T Value;
        private Node<T> NaxtNode { get; set; }
        private Node<T> FirstNode { get; set; }
        public int Count { get; private set; }
        private class Node<T>
        {
            public T Value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                Value = value;
                NextNode = nextNode;
            }

        }

        public void Push(T element)
        {
            if (Count == 0)
            {
                FirstNode = new Node<T>(element);
            }
            else
            {
                FirstNode = new Node<T>(element, FirstNode);
            }
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty stack!");
            }
            var result = FirstNode.Value;
            this.FirstNode = this.FirstNode.NextNode;
            Count--;
            return result;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new LinkedStack<int>();
            int i = 0;
            for (; i < 10; i++)
            {
                stack.Push(i);
            }
            i = 0;
            for (; i < 10; i++)
            {
               var element = stack.Pop();
                Console.WriteLine(element);
            }
        }
    }
}
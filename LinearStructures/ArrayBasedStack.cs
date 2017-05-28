using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrayBasedStackImplementation
{
    public class ArrayStack<T>
    {
        private T[] elements;
        public int Count { get; private set; }
        private const int InitialCapacity = 16;
        private int tailIndex = 0;

        public ArrayStack(int capacity = InitialCapacity)
        {
            elements = new T[capacity];
        }

        private void Grow()
        {
            T[] grownArray = new T[2*elements.Length];
            Array.Copy(this.elements, grownArray, this.elements.Length);
            elements = grownArray;
        }

        public void Push(T item)
        {
            if (Count >= elements.Length - 1)
            {
                Grow();
            }
            elements[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            Count--;
            return elements[Count];
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];
            Array.Copy(elements, newArray, Count);
            return newArray;
        }
    }
    class arrayBasedStack
    {
        static void Main(string[] args)
        {
            var stack = new ArrayStack<int>();
            for (int i = 21; i <= 71; i++)
            {
                stack.Push(i);
            }
            Console.WriteLine(stack.Pop());
            Console.WriteLine(string.Join(", ", stack.ToArray()));
        }
    }
}

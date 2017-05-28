using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedQueueImplementation
{
    public class LinkedQueue<T>
    {
        public int Count { get; private set; }
        private QueueNode<T> FirstNode;
        private QueueNode<T> LastNode;

        public void Enqueue(T element)
        {
            if (Count == 0)
            {
               FirstNode = LastNode = new QueueNode<T>(element);
            }
            else
            {
                var newNode = new QueueNode<T>(element);
                newNode.NextNode = FirstNode;
                FirstNode.PrevNode = newNode;
                FirstNode = newNode;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Empty queue!");
            }

            var result = LastNode.Value;
            LastNode = LastNode.PrevNode;
            Count--;
            return result;
        }

        public T[] ToArray()
        {
            var resultArray = new T[Count];
            var currentNode = FirstNode;
            int index = 0;
            while (index < Count)
            {
                resultArray[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }
            return resultArray;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode (T value )
            {
                this.Value = value;
            }
        }
    }

    class LinkedQueue
    {
        static void Main(string[] args)
        {
            var queue = new LinkedQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            var last = queue.Dequeue();
            Console.WriteLine(last);

            Console.WriteLine(string.Join(", ", queue.ToArray()));
        }
    }
}

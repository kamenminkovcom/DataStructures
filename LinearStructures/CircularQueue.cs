using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;

    public int Count { get; private set; }

    private T[] data;

    private int head = 0;

    private int tail = 0;

    public CircularQueue(int capacity = DefaultCapacity)
    {
        this.data = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count == this.data.Length)
        {
            this.Resize();
        }
        this.data[tail] = element;
        this.tail = (tail + 1) % this.data.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
        var result = this.data[this.head];
        this.head = (this.head + 1) % this.data.Length;
        this.Count--;
        return result;
    }

    public T[] ToArray()
    {
        var result = new T[this.Count];
        this.CopyArray(result);
        return result;
    }

    private void Resize()
    {
        var newData = new T[this.data.Length * 2];
        this.CopyArray(newData);
        this.head = 0;
        this.tail = this.data.Length;
        this.data = newData;
    }

    private void CopyArray(T[] destinationArray)
    {
        int currentIndex = 0;
        int currentHead = this.head;
        while (currentIndex < this.Count)
        {
            destinationArray[currentIndex] = this.data[currentHead];
            currentHead = (currentHead + 1) % this.data.Length;
            currentIndex++;
        }
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}

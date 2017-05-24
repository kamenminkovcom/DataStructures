using System;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;

public class ArrayList<T>
{
    private T[] data;

    public ArrayList()
    {
        this.data = new T[2];
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            this.ValidateIndex(index);
            return this.data[index];
        }

        set
        {
            this.ValidateIndex(index);
            this.data[index] = value;
        }
    }

    public void Add(T item)
    {
        if (this.data.Length == this.Count)
        {
            this.Resize();
        }

        this.data[Count] = item;
        Count++;
    }

    public T RemoveAt(int index)
    {
        this.ValidateIndex(index);

        var removedElement = this.data[index];

        for (int i = index; i < Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }

        this.Count--;

        if (this.Count <= this.data.Length/4)
        {
            this.Shrink();
        }

        return removedElement;
    }

    private void Resize()
    {
        var newData = new T[this.Count * 2];
        Array.Copy(this.data, newData, this.Count);
        this.data = newData;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index > this.Count - 1)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    private void Shrink()
    {
        var newData = new T[this.data.Length/2];
        Array.Copy(this.data, newData, this.Count);
        this.data = newData;
    }

}

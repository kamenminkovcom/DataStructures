using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{

    private class ListNode<T>
    {
        public T Value { get; private set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            Value = value;
        }
    }


    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (Count == 0)
        {
            head = tail = new ListNode<T>(element);
        }
        else
        {
            var newHead = new ListNode<T>(element);
            newHead.NextNode = head;
            head.PrevNode = newHead;
            head = newHead;
        }        
        Count++;
    }

    public void AddLast(T element)
    {
        if (Count == 0)
        {
            tail = head = new ListNode<T>(element);
        }
        else
        {
            var newTail = new ListNode<T>(element);
            newTail.PrevNode = tail;
            tail.NextNode = newTail;
            tail = newTail;
        }
        Count++;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List empty!");
        }
        var result = head.Value;

        if (Count == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.NextNode;
            head.PrevNode = null;
        }
        Count--;
        return result;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List empty!");
        }

        var result = tail.Value;

        if (Count == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.PrevNode;
            tail.NextNode = null;
        }

        Count--;
        return result;
    }

    public void ForEach(Action<T> action)
    {
        var current = head;
        while (current != null)
        {
            action(current.Value);
            current = current.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] resultArray = new T[Count];
        var currentNode = head;
        for (int i = 0; i < Count; i++)
        {
            resultArray[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }
        return resultArray;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}

using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; set; }

    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.Write(string.Join(" ", 2 * indent));

        foreach (var child in this.Children)
        {
            child.Print(indent+1);
        }
        Console.WriteLine(this.Value);
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();
        DFS(this, result);
        return result;
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> result = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current =  queue.Dequeue();
            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
            result.Add(current.Value);
        }
        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (var chield in tree.Children)
        {
            DFS(chield, result);
        }

        result.Add(tree.Value);
    }
}

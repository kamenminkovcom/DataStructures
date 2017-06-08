using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }
    public IList<Tree<T>> Children { get; set; }
    public Tree<T> Parent { get; set; }


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
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);
        foreach (var child in this.Children)
        {
            child.Print(indent + 1);
        }
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
            var current = queue.Dequeue();
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

    public List<Tree<T>> GetMaxDepth()
    {
        List<Tree<T>> path = new List<Tree<T>>();

        foreach (var child in this.Children)
        {
            var help = child.GetMaxDepth();
            if (help.Count > path.Count)
            {
                path = help;
            }
        }

        path.Add(this);
        return path;
    }

    public static void GetAllPaths(Tree<T> node, List<Tree<T>> path, List<List<Tree<T>>> paths)
    {
        if (node == null)
        {
            return;
        }

        path.Add(node);

        if (node.Children.Count == 0)
        {
            List<Tree<T>> newPath = new List<Tree<T>>(path);
            paths.Add(newPath);

        }

        foreach (var child in node.Children)
        {
            GetAllPaths(child, path, paths);
        }

        path.RemoveAt(path.Count - 1);
    }
}

using System;

public class BinaryTree<T> where T : IComparable
{
    private Node rootNode;
    private int Count;

    private class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    public T Value { get; set; }
    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.RightChild = rightChild;
        this.LeftChild = leftChild;
    }

    public void Insert(T value)
    {
        Node newNode = new Node(value);
        if (Count == 0)
        {
            this.rootNode = newNode;
            return;
        }

        Node currentNode = rootNode;
        Node parent = rootNode;
        while (true)
        {
            if (currentNode.Value.CompareTo(newNode.Value) < 0)
            {
                parent = currentNode;
                currentNode = currentNode.LeftChild;
            } else if (currentNode.Value.CompareTo(newNode.Value) > 0)
            {
                parent = currentNode;
                currentNode = currentNode.RightChild;
            }
            if (currentNode == null)
            {
                currentNode = newNode;
                return;
            }
        }
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        Console.WriteLine(new string(' ', 2*indent) + this.Value);

        if (this.LeftChild != null)
        {
            this.LeftChild.PrintIndentedPreOrder(indent+1);
        }
        if (this.RightChild != null)
        {
            this.RightChild.PrintIndentedPreOrder(indent+1);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        if (this.LeftChild != null)
        {
            this.LeftChild.EachInOrder(action);
        }

        action(this.Value);

        if (this.RightChild != null)
        {
            this.RightChild.EachInOrder(action);
        }
    }

    public void EachPostOrder(Action<T> action)
    {
        if (this.LeftChild != null)
        {
            this.LeftChild.EachPostOrder(action);
        }

        if (this.RightChild != null)
        {
            this.RightChild.EachPostOrder(action);
        }

        action(this.Value);
    }
}

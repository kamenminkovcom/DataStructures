using System;
using System.Collections.Generic;
using System.Linq;

class DistanceInLabyrinth
{
    private class Point
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Count { get; set; }

        public Point(int row, int col, int count)
        {
            this.Row = row;
            this.Col = col;
            this.Count = count;
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[][] matrix = new string[n][];
        Point entryPoint;
        var queue = new Queue<Point>();
        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().Select(x => x.ToString()).ToArray();
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == "*")
                {
                    entryPoint = new Point(i, j, 0);
                    queue.Enqueue(entryPoint);
                }
            }
        }

        while (queue.Count > 0)
        {
            var point = queue.Dequeue();
            PushInQueue(queue, point, matrix);
        }

        Print(matrix);
    }

    private static void PushInQueue(Queue<Point> queue, Point point, string[][] matrix)
    {
        if (point.Col > 0 && matrix[point.Row][point.Col - 1] == "0")
        {
            matrix[point.Row][point.Col - 1] = (point.Count + 1).ToString();
            queue.Enqueue(new Point(point.Row, point.Col - 1, point.Count + 1));
        }
        if (point.Col < matrix.GetLongLength(0) - 1 && matrix[point.Row][point.Col + 1] == "0")
        {
            matrix[point.Row][point.Col + 1] = (point.Count + 1).ToString();
            queue.Enqueue(new Point(point.Row, point.Col + 1, point.Count + 1));
        }
        if (point.Row > 0 && matrix[point.Row - 1][point.Col] == "0")
        {
            matrix[point.Row - 1][point.Col] = (point.Count + 1).ToString();
            queue.Enqueue(new Point(point.Row - 1, point.Col, point.Count + 1));
        }
        if (point.Row < matrix.GetLength(0) - 1 && matrix[point.Row + 1][point.Col] == "0")
        {
            matrix[point.Row + 1][point.Col] = (point.Count + 1).ToString();
            queue.Enqueue(new Point(point.Row + 1, point.Col, point.Count + 1));
        }
    }

    private static void Print(string[][] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrix[i][j] = matrix[i][j] == "0" ? "u" : matrix[i][j];
            }
            Console.WriteLine(string.Join("", matrix[i]));
        }
    }
}


namespace GraphTask;

public class Graph
{
    private int[,] _matrix;

    public Graph(int[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            throw new ArgumentException($"Matrix is not quadratic. The size is now: {matrix.GetLength(0)}*{matrix.GetLength(1)}", nameof(matrix));
        }

        _matrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
        Array.Copy(matrix, 0, _matrix, 0, matrix.Length);
    }

    public void DepthFirstSearch(Action<int> action)
    {
        bool[] visitedDepthFirstSearch = new bool[_matrix.GetLength(0)];

        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (visitedDepthFirstSearch[i])
            {
                continue;
            }

            stack.Push(i);
            visitedDepthFirstSearch[i] = true;

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                action(vertex);

                for (int j = _matrix.GetLength(0) - 1; j >= 0; j--)
                {
                    if (_matrix[vertex, j] != 0 && !visitedDepthFirstSearch[j])
                    {
                        stack.Push(j);
                        visitedDepthFirstSearch[j] = true;
                    }
                }
            }
        }
    }

    public void DepthFirstSearchRecursive(Action<int> action)
    {
        bool[] visited = new bool[_matrix.GetLength(0)];

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (!visited[i])
            {
                DepthFirstSearch(i, visited, action);
            }
        }
    }

    private void DepthFirstSearch(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;

        action(vertex);

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (_matrix[vertex, i] != 0 && !visited[i])
            {
                DepthFirstSearch(i, visited, action);
            }
        }
    }

    public void BreadthFirstSearch(Action<int> action)
    {
        bool[] visitedBreadthFirstSearch = new bool[_matrix.GetLength(0)];

        Queue<int> queue = new Queue<int>();

        for (int i = 0; i < _matrix.GetLength(0); i++)
        {
            if (visitedBreadthFirstSearch[i])
            {
                continue;
            }

            queue.Enqueue(i);
            visitedBreadthFirstSearch[i] = true;

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                action(vertex);

                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (_matrix[vertex, j] != 0 && !visitedBreadthFirstSearch[j])
                    {
                        queue.Enqueue(j);
                        visitedBreadthFirstSearch[j] = true;
                    }
                }
            }
        }
    }
}

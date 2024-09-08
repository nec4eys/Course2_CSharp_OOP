using System.ComponentModel;

namespace GraphTask;

public class Graph
{
    private int[,] graphMatrix;

    private bool[] visitedDepthFirstSearch;

    private bool[] visitedBreadthFirstSearch;

    public delegate void Function(int value);

    public Graph(int[,] matrix)
    {
        graphMatrix = matrix;

        visitedDepthFirstSearch = new bool[graphMatrix.GetLength(0)];
        visitedBreadthFirstSearch = new bool[graphMatrix.GetLength(0)];
    }

    public void DepthFirstSearchNonRec(Function action)
    {
        visitedDepthFirstSearch = new bool[graphMatrix.GetLength(0)];

        for (int i = 0; i < graphMatrix.GetLength(0); i++)
        {
            if (!visitedDepthFirstSearch[i])
            {
                Stack<int> stack = new Stack<int>();
                stack.Push(i);
                visitedDepthFirstSearch[i] = true;

                while (stack.Count > 0)
                {
                    int node = stack.Pop();

                    action(node);

                    for (int j = graphMatrix.GetLength(0) - 1; j >= 0; j--)
                    {
                        if (graphMatrix[node, j] == 1 && !visitedDepthFirstSearch[j])
                        {
                            stack.Push(j);
                            visitedDepthFirstSearch[j] = true;
                        }
                    }
                }
            }
        }
    }

    public void DepthFirstSearchRec(Function action)
    {
        bool[] visited = new bool[graphMatrix.GetLength(0)];

        for (int i = 0; i < graphMatrix.GetLength(0); i++)
        {
            if (!visited[i])
            {
                DepthFirstSearch(i, visited, action);
            }
        }
    }

    private void DepthFirstSearch(int node, bool[] visited, Function action)
    {
        visited[node] = true;

        action(node);

        for (int i = 0; i < graphMatrix.GetLength(0); i++)
        {
            if (graphMatrix[node, i] == 1 && !visited[i])
            {
                DepthFirstSearch(i, visited, action);
            }
        }
    }

    public void BreadthFirstSearch(Function action)
    {
        visitedBreadthFirstSearch = new bool[graphMatrix.GetLength(0)];

        for (int i = 0; i < graphMatrix.GetLength(0); i++)
        {
            if (!visitedBreadthFirstSearch[i])
            {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                visitedBreadthFirstSearch[i] = true;

                while (queue.Count > 0)
                {
                    int node = queue.Dequeue();

                    action(node);

                    for (int j = 0; j < graphMatrix.GetLength(0); j++)
                    {
                        if (graphMatrix[node, j] == 1 && !visitedBreadthFirstSearch[j])
                        {
                            queue.Enqueue(j);
                            visitedBreadthFirstSearch[j] = true;
                        }
                    }
                }
            }
        }
    }
}

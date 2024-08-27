namespace GraphTask;

internal class GraphMain
{
    public static void DepthFirstSearch(int[,] graph, int start, bool[] visited)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(start);
        visited[start] = true;

        while (stack.Count > 0)
        {
            int knot = stack.Pop();
            Console.Write(knot + " ");

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[knot, i] == 1 && !visited[i])
                {
                    stack.Push(i);
                    visited[i] = true;
                }
            }
        }
    }

    public static void BreadthFirstSearch(int[,] graph, int start, bool[] visited)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int knot = queue.Dequeue();
            Console.Write(knot + " ");

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (graph[knot, i] == 1 && !visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int[,] graph = new int[,]
        {
            { 0, 1, 0, 0, 0 },
            { 1, 0, 1, 0, 0 },
            { 0, 1, 0, 1, 0 },
            { 0, 0, 1, 0, 1 },
            { 0, 0, 0, 1, 0 }
        };

        Console.WriteLine("Обход в ширину:");

        bool[] visitedBFS = new bool[graph.GetLength(0)];
        
        for (int i = 0; i < visitedBFS.Length; i++)
        {
            if (!visitedBFS[i])
            {
                BreadthFirstSearch(graph, i, visitedBFS);
                Console.WriteLine();
            }
        }

        Console.WriteLine("Обход в глубину:");

        bool[] visitedDFS = new bool[graph.GetLength(0)];

        for (int i = 0; i < visitedDFS.Length; i++)
        {
            if (!visitedDFS[i])
            {
                DepthFirstSearch(graph, i, visitedDFS);
            }
        }
    }
}

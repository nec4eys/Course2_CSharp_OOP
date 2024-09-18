namespace GraphTask;

internal class GraphMain
{
    public static void WriteNodeInConsole(int node)
    {
        Console.WriteLine(node + " ");
    }

    static void Main(string[] args)
    {
        int[,] graphMatrix =
        {
            { 0, 1, 1, 1, 0 },
            { 1, 0, 1, 0, 0 },
            { 1, 1, 0, 0, 1 },
            { 1, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0 }
        };

        Graph graph = new Graph(graphMatrix);

        Console.WriteLine("Обход в ширину:");
        graph.BreadthFirstSearch(WriteNodeInConsole);

        Console.WriteLine("Обход в глубину (не рекурсивный):");
        graph.DepthFirstSearch(WriteNodeInConsole);

        Console.WriteLine("Обход в глубину (рекурсивный):");
        graph.DepthFirstSearchRecursive(WriteNodeInConsole);
    }
}

﻿namespace TreeTask
{
    internal class TreeMain
    {
        public static void WriteNodeInConsole<T>(T node)
        {
            Console.WriteLine(node + " ");
        }

        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine(tree);

            Console.WriteLine("Обход в глубину (рекурсивный):");
            tree.DepthFirstSearchRecursive(WriteNodeInConsole);
            Console.WriteLine();

            Console.WriteLine("Обход в глубину (не рекурсивный):");
            tree.DepthFirstSearch(WriteNodeInConsole);
            Console.WriteLine();

            Console.WriteLine("Обход в ширину:");
            tree.BreadthFirstSearch(WriteNodeInConsole);
            Console.WriteLine();

            Console.WriteLine("Число элементов: " + tree.Count);

            Console.WriteLine(tree.Remove(50));
            Console.WriteLine("После удаления:");
            tree.BreadthFirstSearch(WriteNodeInConsole);
        }
    }
}

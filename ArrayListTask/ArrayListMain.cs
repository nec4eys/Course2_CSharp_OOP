namespace ArrayListTask;

internal class ArrayListMain
{
    static void Main(string[] args)
    {
        CustomList<int> list = new CustomList<int>(8);

        Console.WriteLine(list);

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);
        list.Add(7);
        list.Add(8);
        list.Add(9);

        Console.WriteLine(list);

        Console.WriteLine(list.Count);
        Console.WriteLine(list[1]);

        list.TrimExcess();
        list.RemoveAt(3);

        Console.WriteLine(list);
    }
}

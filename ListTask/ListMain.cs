namespace ListTask;

internal class ListMain
{
    static void Main(string[] args)
    {
        SingleLinkedList<int> list = new SingleLinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Console.WriteLine("Add: " + list);

        Console.WriteLine("Get Head Data: " + list.GetHeadData());

        list.InsertFirst(new ListItem<int>(6));

        Console.WriteLine("Insert First: " + list);

        list.Insert(new ListItem<int>(10), 3);

        Console.WriteLine("Insert: " + list);

        list.Set(3, 11);
        Console.WriteLine("Get after set: " + list.Get(3));

        list.RemoveByValue(2);

        Console.WriteLine("Remove By Value: " + list);

        list.RemoveFirst();

        Console.WriteLine("Remove First: " + list);

        list.Remove(2);

        Console.WriteLine("Remove: " + list);

        Console.WriteLine("Copy: " + list.Copy());

        list.Add(0);
        list.Add(3);
        list.Add(8);
        list.Add(5);
        list.Reverse();

        Console.WriteLine("Reverse: " + list);
    }
}

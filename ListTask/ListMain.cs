namespace ListTask;

internal class ListMain
{
    static void Main(string[] args)
    {

        SinglyLinkedList<int> list = new SinglyLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Console.WriteLine("Add: " + list);

        Console.WriteLine("Get Head Data: " + list.GetFirstData());

        list.InsertFirst(6);

        Console.WriteLine("Insert First: " + list);

        list.Insert(3, 10);

        Console.WriteLine("Insert: " + list);

        list[3] = 11;
        Console.WriteLine("Get after set: " + list[3]);

        list.RemoveByData(2);

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

        Console.WriteLine("Copy: " + list.Copy());
    }
}

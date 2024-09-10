namespace ArrayListTask;

internal class ArrayListMain
{
    static void Main(string[] args)
    {
        var myList = new CustomList<int>(10);

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine(myList.Count);
        Console.WriteLine(myList[1]);

        myList.TrimExcess();

        Console.WriteLine(myList);
    }
}

namespace ArrayListHomeTask;

internal class ArrayListHomeMain
{
    static void Main(string[] args)
    {
        List<string> list1 = new List<string>();

        using (StreamReader reader = new StreamReader("..\\..\\..\\input.txt"))
        {
            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                list1.Add(currentLine);
            }
        }

        Console.WriteLine(nameof(list1) + ":");
        list1.ForEach(Console.WriteLine);

        List<int> list2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        list2.RemoveAll(i => i % 2 == 0);

        Console.WriteLine(nameof(list2) + ":");
        list2.ForEach(Console.WriteLine);

        List<int> list3 = new List<int>() { 1, 6, 1, 2, 4, 1, 2, 3 };
        List<int> list4 = new List<int>();

        foreach (int i in list3)
        {
            if (!list4.Contains(i))
            {
                list4.Add(i);
            }
        }

        Console.WriteLine(nameof(list4) + ":");
        list4.ForEach(Console.WriteLine);
    }
}

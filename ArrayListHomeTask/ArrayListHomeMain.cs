namespace ArrayListHomeTask;

internal class ArrayListHomeMain
{
    public static List<string> ReadFile(string filePath)
    {
        List<string> list = new List<string>();

        try
        {
            using StreamReader reader = new StreamReader(filePath);

            string? line;

            while ((line = reader.ReadLine()) != null)
            {
                list.Add(line);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Случилась непредвиденная ошибка! " + e.Message);
        }

        return list;
    }

    public static List<int> RemoveEvenNumbers(List<int> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int item = list[i];

            if (item % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }

        return list;
    }

    public static List<T> RemoveDuplicates<T>(List<T> list)
    {
        List<T> listWithoutDuplicates = new List<T>(list.Count);

        foreach (T item in list)
        {
            if (!listWithoutDuplicates.Contains(item))
            {
                listWithoutDuplicates.Add(item);
            }
        }

        return listWithoutDuplicates;
    }

    static void Main(string[] args)
    {
        List<string> linesList = ReadFile("..\\..\\..\\input.txt");

        Console.WriteLine("Task 1:");
        linesList.ForEach(Console.WriteLine);

        List<int> oddNumbersList = RemoveEvenNumbers([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);

        Console.WriteLine("Task 2:");
        oddNumbersList.ForEach(Console.WriteLine);

        var listWithoutDuplicates = RemoveDuplicates([1, 6, 1, 2, 4, 1, 2, 3]);

        Console.WriteLine("Task 3:");
        listWithoutDuplicates.ForEach(Console.WriteLine);
    }
}

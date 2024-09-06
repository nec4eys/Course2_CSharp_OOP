using System.Collections.Generic;

namespace ArrayListHomeTask;

internal class ArrayListHomeMain
{
    public static List<string> GetListWithFileLines(string filePath)
    {
        List<string> linesFromFile = new List<string>();

        using StreamReader reader = new StreamReader(filePath);
        
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            linesFromFile.Add(line);
        }

        return linesFromFile;
    }

    public static void RemoveEvenNumbers(List<int> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<T> GetListWithoutDuplicates<T>(List<T> list)
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

        try
        {
            List<string> linesList = GetListWithFileLines("..\\..\\..\\input.txt");
            Console.WriteLine("Task 1:");
            linesList.ForEach(Console.WriteLine);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Случилась непредвиденная ошибка! " + e.Message);
        }

        List<int> oddNumbersList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        RemoveEvenNumbers(oddNumbersList);

        Console.WriteLine("Task 2:");
        oddNumbersList.ForEach(Console.WriteLine);

        List<int> listWithoutDuplicates = GetListWithoutDuplicates([1, 6, 1, 2, 4, 1, 2, 3]);

        Console.WriteLine("Task 3:");
        listWithoutDuplicates.ForEach(Console.WriteLine);
    }
}

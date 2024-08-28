using System.Collections.Generic;

namespace ArrayListHomeTask;

internal class ArrayListHomeMain
{
    public static void Task1()
    {
        List<string> listString = new List<string>();

        try
        {
            using StreamReader reader = new StreamReader("..\\..\\..\\input.txt");

            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                listString.Add(currentLine);
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

        Console.WriteLine("Task 1:");
        listString.ForEach(Console.WriteLine);
    }

    public static void Task2()
    {
        List<int> listInt = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        for (int i = 0; i < listInt.Count; i++)
        {
            int item = listInt[i];
            if (item % 2 == 0)
            {
                listInt.RemoveAt(i);
                i--;
            }
        }

        Console.WriteLine("Task 2:");
        listInt.ForEach(Console.WriteLine);
    }

    public static void Task3()
    {
        List<int> listInt = new List<int>() { 1, 6, 1, 2, 4, 1, 2, 3 };
        List<int> listIntWithoutDuplicateItems = new List<int>(listInt.Count);

        foreach (int item in listInt)
        {
            if (!listIntWithoutDuplicateItems.Contains(item))
            {
                listIntWithoutDuplicateItems.Add(item);
            }
        }

        Console.WriteLine("Task 3:");
        listIntWithoutDuplicateItems.ForEach(Console.WriteLine);
    }

    static void Main(string[] args)
    {
        Task1();

        Task2();

        Task3();
    }
}

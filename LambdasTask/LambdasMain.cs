namespace LambdasTask;

internal class LambdasMain
{
    static void Main(string[] args)
    {
        List<Person> people =
        [
            new Person("Q", 25),
            new Person("W", 17),
            new Person("E", 19),
            new Person("Q", 32),
            new Person("R", 29),
            new Person("T", 15),
            new Person("Y", 22),
            new Person("U", 40)
        ];

        // А и Б
        List<string> uniqueNames = people
            .Select(p => p.Name)
            .Distinct()
            .ToList();

        Console.WriteLine("Имена: " + string.Join(", ", uniqueNames) + ".");

        // В
        List<Person> youngPeople = people
            .Where(p => p.Age < 18)
            .ToList();

        if (youngPeople.Count != 0)
        {
            Console.WriteLine($"Средний возраст людей младше 18 лет: {youngPeople.Average(p => p.Age)}");
        }
        else
        {
            Console.WriteLine("В списке нет людей младше 18");
        }

        // Г
        Dictionary<string, double> averageAgesByNames = people
            .GroupBy(p => p.Name)
            .ToDictionary(g => g.Key, g => g.Average(p => p.Age));

        Console.WriteLine("Средний возраст по именам:");

        foreach (KeyValuePair<string, double> item in averageAgesByNames)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Д
        IEnumerable<Person> peopleInRange = people
            .Where(p => p.Age >= 20 && p.Age <= 45)
            .OrderByDescending(p => p.Age);

        Console.WriteLine("Люди, возраст которых от 20 до 45:");

        foreach (Person person in peopleInRange)
        {
            Console.WriteLine(person.Name);
        }
    }
}

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
        List<string> uniqueNames = people.Select(p => p.Name).Distinct().ToList();

        Console.WriteLine("Имена: " + string.Join(", ", uniqueNames) + ".");

        // В
        var youngPeople = people.Where(p => p.Age < 18);

        Console.WriteLine($"Средний возраст людей младше 18 лет: {(youngPeople.Any() ? youngPeople.Average(p => p.Age) : 0)}");

        // Г
        var averageAgesByName = people.GroupBy(p => p.Name).ToDictionary(g => g.Key, g => g.Average(p => p.Age));

        Console.WriteLine("Средний возраст по именам:");

        foreach (var item in averageAgesByName)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        // Д
        Console.WriteLine("Люди, возраст которых от 20 до 45:");
        people.Where(p => p.Age >= 20 && p.Age <= 45).OrderByDescending(p => p.Age).Select(p => p.Name).ToList().ForEach(Console.WriteLine);
    }
}

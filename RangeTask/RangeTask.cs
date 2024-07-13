namespace RangeTask
{
    internal class RangeTask
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(3.0, 7.0); 
            Range range2 = new Range(3.0, 7.0); // для проверки использовать разные значения

            double number = 5.0;

            Console.WriteLine($"Длинна: {range1.GetLength()}");
            Console.WriteLine($"Принадлежность числа диапазону: {range1.IsInside(number)}");
            Console.WriteLine($"Пересечение:");

            // TO DO 
            // проверка пересечения. два варианта, для проверки возвращения null
            // проверка объединения. два варианта, для проверки возвращения кусков
            // проверка разности. три варианта, для проверки возвращения кусков
        }
    }
}

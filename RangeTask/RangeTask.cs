namespace RangeTask
{
    internal class RangeTask
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(1.0, 10.0); 
            Range range2 = new Range(1.0, 8.0);

            double number = 5.0;

            Console.WriteLine($"Длинна: {range1.GetLength()}");
            Console.WriteLine($"Принадлежность числа диапазону: {range1.IsInside(number)}");

            Range intersectionRange = range1.GetRangesIntersection(range2);

            if (intersectionRange != null)
            {
                Console.WriteLine($"Пересечение: {intersectionRange.GetLength()}");
            }

            Range[] unificationsRange = range1.GetRangesUnion(range2);

            foreach (Range range in unificationsRange)
            {
                Console.WriteLine($"Объединение: {range.GetLength()}");
            }

            Range[] differencesRange = range1.GetRangesDifference(range2);

            foreach (Range range in differencesRange)
            {
                Console.WriteLine($"Разность: {range.GetLength()}");
            }
        }
    }
}

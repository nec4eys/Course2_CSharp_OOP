namespace RangeTask
{
    internal class RangeMain
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(1.0, 4.0);
            Range range2 = new Range(6.0, 9.0);

            double number = 5.0;

            Console.WriteLine($"Длина: {range1.GetLength()}");
            Console.WriteLine($"Принадлежность числа диапазону: {range1.IsInside(number)}");

            Range? intersection = range1.GetIntersection(range2);

            if (intersection != null)
            {
                Console.WriteLine($"Пересечение: {intersection}");
            }
            else
            {
                Console.WriteLine("Пересечения нет");
            }

            Range[] union = range1.GetUnion(range2);

            foreach (Range range in union)
            {
                Console.WriteLine($"Объединение: {range}");
            }

            Range[] difference = range1.GetDifference(range2);

            if (difference.Length != 0)
            {
                foreach (Range range in difference)
                {
                    Console.WriteLine($"Разность: {range}");
                }
            }
            else
            {
                Console.WriteLine("Разности нет");
            }
        }
    }
}

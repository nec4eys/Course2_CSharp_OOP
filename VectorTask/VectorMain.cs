namespace VectorTask;

internal class VectorMain
{
    static void Main(string[] args)
    {
        Vector vector1 = new Vector(5);
        Vector vector2 = new Vector(vector1);
        Vector vector3 = new Vector([1, 2, 3]);
        Vector vector4 = new Vector(5, [4, 5, 6]);
        Vector vector5 = new Vector(2, [7, 8]);
        Vector vector6 = new Vector(1, [8, 9, 10]);

        Console.WriteLine($"vector1 = {vector1}");
        Console.WriteLine($"vector2 = {vector2}");
        Console.WriteLine($"vector3 = {vector3}");
        Console.WriteLine($"vector4 = {vector4}");
        Console.WriteLine($"vector5 = {vector5}");
        Console.WriteLine($"vector6 = {vector6}");

        // статические методы
        Console.WriteLine($"Сложение двух векторов: {Vector.GetSum(vector3, vector5)}");
        Console.WriteLine($"Вычитание векторов: {Vector.GetDifference(vector4, vector6)}");
        Console.WriteLine($"Скалярное произведение векторов: {Vector.GetScalarProduct(vector3, vector4)}");

        // нестатические методы
        vector1.Add(vector4);
        Console.WriteLine($"Прибавление вектора: {vector1}");

        vector4.Subtract(vector5);
        Console.WriteLine($"Вычитание вектора: {vector4}");

        double scalar = 5.0;
        vector5.MultiplyByScalar(scalar);
        Console.WriteLine($"Умножение вектора на скаляр: {vector5}");

        vector4.Turn();
        Console.WriteLine($"Разворот вектора: {vector4}");

        Console.WriteLine($"Получение длины вектора: {vector4.GetLength()}");

        vector6.SetComponentByIndex(0, 1.0);
        Console.WriteLine($"Установка и получение компонента вектора по индексу: {vector6.GetComponentByIndex(0)}");

        Vector vector7 = new Vector(vector1);
        Vector vector8 = new Vector(vector7);
        Console.WriteLine($"Проверка на равенство векторов: {vector7.Equals(vector8)}");
    }
}

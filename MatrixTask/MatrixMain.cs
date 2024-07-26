namespace MatrixTask;

internal class MatrixMain
{
    static void Main(string[] args)
    {
        Matrix matrix1 = new Matrix(3, 3);
        Matrix matrix2 = new Matrix(matrix1);

        Vector[] vectors =
        {
            new Vector([1, 2, 3]),
            new Vector([4, 5, 6]),
            new Vector([7, 8, 9])
        };
        Matrix matrix3 = new Matrix(vectors);

        double[,] values = new double[,]
        {
            { 10, 11 },
            { 13, 14 },
            { 14, 15 }
        };
        Matrix matrix4 = new Matrix(values);

        Vector[] vectors1 = { };
        Matrix matrix5 = new Matrix(vectors1);

        Console.WriteLine($"matrix1: {matrix1}");
        Console.WriteLine($"matrix2: {matrix2}");
        Console.WriteLine($"matrix3: {matrix3}");
        Console.WriteLine($"matrix4: {matrix4}");
        Console.WriteLine($"matrix5: {matrix5}");

        // нестатические методы

        Vector vector = new Vector([-1, -2, -3]);
        Console.WriteLine($"Row by index: {matrix1.GetRowByIndex(0)}");

        matrix1.SetRowByIndex(0, vector);
        Console.WriteLine($"New Row by index: {matrix1.GetRowByIndex(0)}");
        Console.WriteLine($"Column by index: {matrix1.GetColumnByIndex(0)}");

        matrix4.Transpose();
        Console.WriteLine($"matrix4 after transpose: {matrix4}");

        matrix4.MultiplyByScalar(2);
        Console.WriteLine($"matrix4 after multiplication by scalar: {matrix4}");

        Console.WriteLine($"Determinant: {matrix3.GetDeterminant()}");

        matrix1.Add(matrix3);
        Console.WriteLine($"matrix1.Add(matrix3): {matrix1}");

        matrix1.Subtract(matrix3);
        Console.WriteLine($"matrix1.Subtract(matrix3): {matrix1}");

        matrix3.MultiplyByVector(vector);
        Console.WriteLine($"matrix3 after multiplication by vector: {matrix3}");

        // статические методы

        Vector[] vectors2 =
        {
            new Vector([10, 2, 3]),
            new Vector([4, 50, 6]),
            new Vector([7, 8, 90])
        };
        Vector[] vectors3 =
        {
            new Vector([1, 20, 3]),
            new Vector([4, 5, 60]),
            new Vector([70, 8, 9])
        };

        Matrix matrix6 = new Matrix(vectors2);
        Matrix matrix7 = new Matrix(vectors3);

        Console.WriteLine($"new matrix = matrix6 + matrix7: {Matrix.GetAmount(matrix6, matrix7)}");
        Console.WriteLine($"new matrix = matrix6 - matrix7: {Matrix.GetDifference(matrix6, matrix7)}");
        Console.WriteLine($"new matrix = matrix6 * matrix7: {Matrix.GetMultiplication(matrix6, matrix7)}");
    }
}

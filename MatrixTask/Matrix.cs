using System.Text;
using VectorTask;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _rows;

    public int RowsCount => _rows.Length;

    public int ColumnsCount => _rows[0].Size;

    public Matrix(int rowsCount, int columnsCount)
    {
        if (rowsCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rowsCount), $"RowsCount <= 0. Specified {nameof(rowsCount)}: {rowsCount}");
        }

        if (columnsCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(columnsCount), $"ColumnsCount <= 0. Specified {nameof(columnsCount)}: {columnsCount}");
        }

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            _rows[i] = new Vector(columnsCount);
        }
    }

    public Matrix(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        _rows = new Vector[matrix.RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            _rows[i] = new Vector(matrix._rows[i]);
        }
    }

    public Matrix(double[,] values)
    {
        if (values.Length == 0)
        {
            throw new ArgumentException($"The array {nameof(values)} is empty", nameof(values));
        }

        int rowsCount = values.GetLength(0);
        int columnsCount = values.GetLength(1);

        _rows = new Vector[rowsCount];

        for (int i = 0; i < rowsCount; i++)
        {
            double[] row = new double[columnsCount];

            for (int j = 0; j < columnsCount; j++)
            {
                row[j] = values[i, j];
            }

            _rows[i] = new Vector(row);
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors == null)
        {
            throw new ArgumentNullException(nameof(vectors));
        }

        if (vectors.Length == 0)
        {
            throw new ArgumentException($"The array {nameof(vectors)} is empty", nameof(vectors));
        }

        _rows = new Vector[vectors.Length];

        int columnsCount = 0;

        foreach (Vector vector in vectors)
        {
            if (vector.Size > columnsCount)
            {
                columnsCount = vector.Size;
            }
        }

        for (int i = 0; i < RowsCount; i++)
        {
            double[] values = new double[columnsCount];

            for (int j = 0; j < vectors[i].Size; j++)
            {
                values[j] = vectors[i].GetComponentByIndex(j);
            }

            _rows[i] = new Vector(values);
        }
    }

    public Vector GetRowByIndex(int index)
    {
        if (index < 0 || index >= RowsCount)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {RowsCount - 1}]. Specified {nameof(index)}: {index}");
        }

        return new Vector(_rows[index]);
    }

    public void SetRowByIndex(int index, Vector vector)
    {
        if (index < 0 || index >= RowsCount)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {RowsCount - 1}]. Specified {nameof(index)}: {index}");
        }

        if (vector == null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        if (vector.Size != ColumnsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector), $"The size of {nameof(vector)} != columnsCount. Specified {nameof(vector.Size)}: {vector.Size}");
        }

        _rows[index] = new Vector(vector);
    }

    public Vector GetColumnByIndex(int index)
    {
        if (index < 0 || index >= ColumnsCount)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0, {ColumnsCount - 1}]. Specified {nameof(index)}: {index}");
        }

        double[] values = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            values[i] = _rows[i].GetComponentByIndex(index);
        }

        return new Vector(values);
    }

    public void Transpose()
    {
        Vector[] newRows = new Vector[ColumnsCount];

        for (int i = 0; i < ColumnsCount; i++)
        {
            newRows[i] = GetColumnByIndex(i);
        }

        _rows = newRows;
    }

    public void MultiplyByScalar(double scalar)
    {
        foreach (Vector row in _rows)
        {
            row.MultiplyByScalar(scalar);
        }
    }

    public double GetDeterminant()
    {
        if (RowsCount != ColumnsCount)
        {
            throw new InvalidOperationException($"This matrix is not quadratic. Specified size: {RowsCount}*{ColumnsCount}");
        }

        double[,] matrixArray = new double[RowsCount, ColumnsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            for (int j = 0; j < ColumnsCount; j++)
            {
                matrixArray[i, j] = _rows[i].GetComponentByIndex(j);
            }
        }

        return GetDeterminant(matrixArray);
    }

    private static double GetDeterminant(double[,] matrix)
    {
        if (matrix.Length == 1)
        {
            return matrix[0, 0];
        }

        double determinant = 0;
        int matrixSize = matrix.GetLength(0);

        for (int i = 0; i < matrixSize; i++)
        {
            double[,] matrixMinor = new double[matrixSize - 1, matrixSize - 1];

            for (int j = 1; j < matrixSize; j++)
            {
                int offset = 0;

                for (int k = 0; k < matrixSize; k++)
                {
                    if (k == i)
                    {
                        continue;
                    }

                    matrixMinor[j - 1, offset] = matrix[j, k];
                    offset++;
                }
            }

            determinant += Math.Pow(-1, i + 2) * matrix[0, i] * GetDeterminant(matrixMinor);
        }

        return determinant;
    }

    public Vector MultiplyByVector(Vector vector)
    {
        if (vector == null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        if (vector.Size != ColumnsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector), $"The size of {nameof(vector)} != columnsCount. Specified {nameof(vector.Size)}: {vector.Size}");
        }

        double[] values = new double[RowsCount];

        for (int i = 0; i < RowsCount; i++)
        {
            values[i] = Vector.GetScalarProduct(_rows[i], vector);
        }

        return new Vector(values);
    }

    private static void CheckMatrixSizesEquality(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(matrix1) + ", " + nameof(matrix2), 
                $"Dimensions of the matrices do not match. Specified sizes: {matrix1.RowsCount}*{matrix1.ColumnsCount} and {matrix2.RowsCount}*{matrix2.ColumnsCount}");
        }
    }

    public void Add(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        CheckMatrixSizesEquality(this, matrix);

        for (int i = 0; i < RowsCount; ++i)
        {
            _rows[i].Add(matrix._rows[i]);
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        CheckMatrixSizesEquality(this, matrix);

        for (int i = 0; i < RowsCount; ++i)
        {
            _rows[i].Subtract(matrix._rows[i]);
        }
    }

    public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        CheckMatrixSizesEquality(matrix1, matrix2);

        Matrix resultMatrix = new Matrix(matrix1);
        resultMatrix.Add(matrix2);

        return resultMatrix;
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        CheckMatrixSizesEquality(matrix1, matrix2);

        Matrix resultMatrix = new Matrix(matrix1);
        resultMatrix.Subtract(matrix2);

        return resultMatrix;
    }

    public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        if (matrix1.ColumnsCount != matrix2.RowsCount)
        {
            throw new ArgumentOutOfRangeException(nameof(matrix1) + ", " + nameof(matrix2), $"Column count {nameof(matrix1)} != row count {nameof(matrix2)}");
        }

        double[,] resultArray = new double[matrix1.RowsCount, matrix2.ColumnsCount];

        for (int i = 0; i < matrix1.RowsCount; i++)
        {
            for (int j = 0; j < matrix2.ColumnsCount; j++)
            {
                resultArray[i, j] = Vector.GetScalarProduct(matrix1._rows[i], matrix2.GetColumnByIndex(j));
            }
        }

        return new Matrix(resultArray);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        foreach (Vector row in _rows)
        {
            stringBuilder.Append(row).Append(", ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int hash = 1;

        foreach (Vector row in _rows)
        {
            hash = prime * hash + row.GetHashCode();
        }

        return hash;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        Matrix matrix = (Matrix)obj;

        if (RowsCount != matrix.RowsCount || ColumnsCount != matrix.ColumnsCount)
        {
            return false;
        }

        for (int i = 0; i < RowsCount; i++)
        {
            if (!_rows[i].Equals(matrix._rows[i]))
            {
                return false;
            }
        }

        return true;
    }
}

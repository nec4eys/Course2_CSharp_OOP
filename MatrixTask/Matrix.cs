using System.Text;

namespace MatrixTask;

public class Matrix
{
    private Vector[] _lines;

    private int _columnCount;

    private int _rowCount;

    public int[] Size
    {
        get { return [_rowCount, _columnCount]; }
    }

    public Matrix(int rowCount, int columnCount)
    {
        if (rowCount < 0 || columnCount < 0)
        {
            throw new ArgumentOutOfRangeException($"rowCount or columnCount < 0. Now {rowCount} and {columnCount}", nameof(rowCount) + ", " + nameof(columnCount)); 
        }

        _rowCount = rowCount;
        _columnCount = columnCount;
        _lines = new Vector[_rowCount];

        for (int i = 0; i < _rowCount; i++)
        {
            _lines[i] = new Vector(_columnCount);
        }
    }

    public Matrix(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix), "argument matrix = null");
        }

        int[] matrixSize = matrix.Size;
        _rowCount = matrixSize[0];
        _columnCount = matrixSize[1];

        _lines = new Vector[_rowCount];
        Array.Copy(matrix._lines, _lines, _rowCount);
    }

    public Matrix(double[,] values)
    {
        if (values.Length == 0)
        {
            throw new ArgumentException("the array values is empty", nameof(values));
        }

        _rowCount = values.GetLength(0);
        _columnCount = values.GetLength(1);

        _lines = new Vector[_rowCount];

        for (int i = 0; i < _rowCount; i++)
        {
            double[] line = new double[_columnCount];

            for (int j = 0; j < _columnCount; j++)
            {
                line[j] = values[i, j];
            }

            _lines[i] = new Vector(line);
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors == null)
        {
            throw new ArgumentNullException(nameof(vectors), "argument vectors = null");
        }

        _rowCount = vectors.Length;
        
        if (vectors.Length == 0)
        {
            _columnCount = 0;
        }
        else
        {
            _columnCount = vectors[0].Size;
        }

        _lines = new Vector[_rowCount];
        Array.Copy(vectors, _lines, _rowCount);
    }

    public Vector GetRowByIndex(int index)
    {
        if (index < 0 || index >= _rowCount)
        {
            throw new IndexOutOfRangeException($"index is out of range [0, {_rowCount}]. Now {index}]");
        }

        return _lines[index];
    }

    public void SetRowByIndex(int index, Vector vector)
    {
        if (index < 0 || index >= _rowCount)
        {
            throw new IndexOutOfRangeException($"index is out of range [0, {_rowCount}]. Now {index}]");
        }

        if (vector == null)
        {
            throw new ArgumentNullException(nameof(vector), "argument vector = null");
        }

        if (vector.Size != _columnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector), $"the size of vector != columnCount. Now {vector.Size}");
        }

        _lines[index] = new Vector(vector);
    }

    public Vector GetColumnByIndex(int index)
    {
        if (index < 0 || index >= _columnCount)
        {
            throw new IndexOutOfRangeException($"index is out of range [0, {_columnCount}]. Now {index}]");
        }

        double[] values = new double[_rowCount];

        for (int i = 0; i < _rowCount; i++)
        {
            values[i] = _lines[i].GetComponentByIndex(index);
        }

        return new Vector(values);
    }

    public void Transpose()
    {
        Vector[] newLines = new Vector[_columnCount];

        for (int i = 0; i < _columnCount; i++)
        {
            newLines[i] = GetColumnByIndex(i);
        }

        int temp = _columnCount;
        _columnCount = _rowCount;
        _rowCount = temp;

        _lines = newLines;
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _rowCount; i++)
        {
            _lines[i].MultiplyByScalar(scalar);
        }
    }

    public double GetDeterminant()
    {
        if (_rowCount != _columnCount)
        {
            throw new InvalidOperationException("This matrix is not quadratic");
        }

        double[,] arrayMatrix = new double[_rowCount, _columnCount];

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _columnCount; j++)
            {
                arrayMatrix[i, j] = _lines[i].GetComponentByIndex(j);
            }
        }

        return GetDeterminant(arrayMatrix);
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

    public void MultiplyByVector(Vector vector)
    {
        if (vector == null)
        {
            throw new ArgumentNullException(nameof(vector), "argument vector = null");
        }

        if (vector.Size != _rowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(vector), $"the size of vector != rowCount. Now {vector.Size}");
        }

        _columnCount = 1;

        for (int i = 0; i < _rowCount; i++)
        {
            _lines[i] = new Vector([Vector.GetScalarProduct(_lines[i], vector)]);
        }
    }

    public void Add(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix), "argument matrix = null");
        }

        int[] matrixSize = matrix.Size;

        if (_rowCount != matrixSize[0] || _columnCount != matrixSize[1])
        {
            throw new ArgumentOutOfRangeException("Dimensions of the matrices do not match", nameof(matrixSize));
        }

        for (int i = 0; i < _rowCount; ++i)
        {
            _lines[i].Add(matrix.GetRowByIndex(i));
        }
    }

    public void Subtract(Matrix matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix), "argument matrix = null");
        }

        int[] matrixSize = matrix.Size;

        if (_rowCount != matrixSize[0] || _columnCount != matrixSize[1])
        {
            throw new ArgumentOutOfRangeException("Dimensions of the matrices do not match", nameof(matrixSize));
        }

        for (int i = 0; i < _rowCount; ++i)
        {
            _lines[i].Subtract(matrix.GetRowByIndex(i));
        }
    }

    public static Matrix GetAmount(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix1) + ", " + nameof(matrix2), "arguments matrix1 = null or matrix2 = null");
        }

        int[] matrix1Size = matrix1.Size;
        int[] matrix2Size = matrix2.Size;

        if ((matrix1Size[0] != matrix2Size[0]) || (matrix1Size[1] != matrix2Size[1]))
        {
            throw new ArgumentOutOfRangeException("Dimensions of the matrices do not match", nameof(matrix1Size) + ", " + nameof(matrix2Size));
        }

        Vector[] resultMatrix = new Vector[matrix1Size[0]];

        for (int i = 0; i < matrix1Size[0]; i++)
        {
            resultMatrix[i] = Vector.GetAmount(matrix1.GetRowByIndex(i), matrix2.GetRowByIndex(i));
        }

        return new Matrix(resultMatrix);
    }

    public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix1) + ", " + nameof(matrix2), "arguments matrix1 = null or matrix2 = null");
        }

        int[] matrix1Size = matrix1.Size;
        int[] matrix2Size = matrix2.Size;

        if ((matrix1Size[0] != matrix2Size[0]) || (matrix1Size[1] != matrix2Size[1]))
        {
            throw new ArgumentOutOfRangeException("Dimensions of the matrices do not match", nameof(matrix1Size) + ", " + nameof(matrix2Size));
        }

        Vector[] resultMatrix = new Vector[matrix1Size[0]];

        for (int i = 0; i < matrix1Size[0]; i++)
        {
            resultMatrix[i] = Vector.GetDifference(matrix1.GetRowByIndex(i), matrix2.GetRowByIndex(i));
        }

        return new Matrix(resultMatrix);
    }

    public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 == null || matrix2 == null)
        {
            throw new ArgumentNullException(nameof(matrix1) + ", " + nameof(matrix2), "arguments matrix1 = null or matrix2 = null");
        }

        int[] matrix1Size = matrix1.Size;
        int[] matrix2Size = matrix2.Size;

        if ((matrix1Size[1] != matrix2Size[0]))
        {
            throw new ArgumentOutOfRangeException("Column count first matrix != row count second matrix", nameof(matrix1Size) + ", " + nameof(matrix2Size));
        }

        double[,] resultMatrix = new double[matrix1Size[0], matrix2Size[1]];

        for (int i = 0; i < matrix1Size[0]; i++)
        {
            for (int j = 0; j < matrix2Size[1]; j++)
            {
                resultMatrix[i, j] = Vector.GetScalarProduct(matrix1.GetRowByIndex(i), matrix2.GetColumnByIndex(j));
            }
        }

        return new Matrix(resultMatrix);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{}");

        foreach (Vector line in _lines)
        {
            stringBuilder.Insert(stringBuilder.Length - 1, $"{line},");
        }

        if (_lines.Length != 0)
        {
            stringBuilder.Remove(stringBuilder.Length - 2, 1);
        }

        return stringBuilder.ToString();
    }
}

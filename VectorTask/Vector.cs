using System.Text;

namespace VectorTask;

public class Vector
{
    private double[] _components;

    public int Size => _components.Length;

    public Vector(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Size of the vector must be > 0. Specified {nameof(size)}: {size}");
        }

        _components = new double[size];
    }

    public Vector(Vector vector) : this(vector._components) { }

    public Vector(double[] components)
    {
        if (components.Length == 0)
        {
            throw new ArgumentException($"Size of the vector must be > 0. Specified {nameof(components.Length)}: {components.Length}");
        }

        _components = new double[components.Length];
        Array.Copy(components, _components, components.Length);
    }

    public Vector(int componentsCount, double[] components) : this(componentsCount)
    {
        Array.Copy(components, _components, Math.Min(componentsCount, components.Length));
    }

    public void Add(Vector vector)
    {
        int vectorSize = vector.Size;

        if (vectorSize > Size)
        {
            Array.Resize(ref _components, vectorSize);
        }

        for (int i = 0; i < vectorSize; i++)
        {
            _components[i] += vector._components[i];
        }
    }

    public void Subtract(Vector vector)
    {
        int vectorSize = vector.Size;

        if (vectorSize > Size)
        {
            Array.Resize(ref _components, vectorSize);
        }

        for (int i = 0; i < vectorSize; i++)
        {
            _components[i] -= vector._components[i];
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void Turn()
    {
        MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        double lengthSquare = 0;

        foreach (double component in _components)
        {
            lengthSquare += component * component;
        }

        return Math.Sqrt(lengthSquare);
    }

    public double GetComponentByIndex(int index)
    {
        if (index < 0 || index >= _components.Length)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0; {_components.Length - 1}]. Specified {nameof(index)}: {index}");
        }

        return _components[index];
    }

    public void SetComponentByIndex(int index, double component)
    {
        if (index < 0 || index >= _components.Length)
        {
            throw new IndexOutOfRangeException($"Index is out of range [0; {_components.Length - 1}]. Specified {nameof(index)}: {index}");
        }

        _components[index] = component;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        Vector resultVector = new Vector(vector1);
        resultVector.Add(vector2);

        return resultVector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        Vector resultVector = new Vector(vector1);
        resultVector.Subtract(vector2);

        return resultVector;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        int minSize = Math.Min(vector1.Size, vector2.Size);

        double scalarProduct = 0.0;

        for (int i = 0; i < minSize; i++)
        {
            scalarProduct += vector1._components[i] * vector2._components[i];
        }

        return scalarProduct;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder("{");

        foreach (double component in _components)
        {
            stringBuilder.Append($"{component}, ");
        }

        return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append('}').ToString();
    }

    public override int GetHashCode()
    {
        int prime = 17;
        int hash = 1;

        foreach (double component in _components)
        {
            hash = prime * hash + component.GetHashCode();
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

        Vector vector = (Vector)obj;

        if (Size != vector.Size)
        {
            return false;
        }

        for (int i = 0; i < _components.Length; i++)
        {
            if (_components[i] != vector._components[i])
            {
                return false;
            }
        }

        return true;
    }
}

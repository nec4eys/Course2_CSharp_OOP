using System.Numerics;

namespace VectorTask;

public class Vector
{
    public double[] Components { get; set; }

    public Vector(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("n <= 0");
        }

        Components = new double[n];

        for (int i = 0; i < n; i++)
        {
            Components[i] = 0.0;
        }
    }

    public Vector(Vector vector) : this(vector.Components) { }

    public Vector(double[] components)
    {
        if (components.Length == 0)
        {
            throw new ArgumentException("n <= 0");
        }

        Components = components;
    }

    public Vector(int n, double[] components) : this(n)
    {
        for (int i = 0, j = 0; i < components.Length && j < n; i++, j++)
        {
            Components[i] = components[i];
        }
    }

    public void AddVector(Vector vector)
    {
        int vectorSize = vector.GetSize();

        double[] components = new double[Math.Max(Components.Length, vectorSize)];

        for (int i = 0; i < components.Length; i++)
        {
            if (i >= Components.Length)
            {
                components[i] = vector.Components[i];
                continue;
            }

            if (i >= vectorSize)
            {
                components[i] = Components[i];
                continue;
            }

            components[i] = Components[i] + vector.Components[i];
        }

        Components = components;
    }

    public void SubtractionVector(Vector vector)
    {
        int vectorSize = vector.GetSize();

        double[] components = new double[Math.Max(Components.Length, vectorSize)];

        for (int i = 0; i < components.Length; i++)
        {
            if (i >= Components.Length)
            {
                components[i] = -1 * vector.Components[i];
                continue;
            }

            if (i >= vectorSize)
            {
                components[i] = Components[i];
                continue;
            }

            components[i] = Components[i] - vector.Components[i];
        }

        Components = components;
    }

    public void MultiplicationVectorByScalar(double scalar)
    {
        for (int i = 0; i < Components.Length; i++)
        {
            Components[i] *= scalar;
        }
    }

    public void RotateVector()
    {
        MultiplicationVectorByScalar(-1);
    }

    public double GetVectorLength()
    {
        double length = 0;

        for (int i = 0; i < Components.Length; i++)
        {
            length += Math.Pow(Components[i], 2);
        }

        return Math.Sqrt(length);
    }

    public double GetComponentByIndex(int index)
    {
        if (index < 0 || index >= Components.Length)
        {
            throw new ArgumentException("bad index");
        }

        return Components[index];
    }

    public void SetComponentByIndex(int index, double component)
    {
        if (index < 0 || index >= Components.Length)
        {
            return;
        }

        Components[index] = component;
    }

    public static Vector GetSummedVectors(Vector vector1, Vector vector2)
    {
        int vector1Size = vector1.GetSize();
        int vector2Size = vector2.GetSize();

        double[] components = new double[Math.Max(vector1Size, vector2Size)];

        for (int i = 0; i < components.Length; i++)
        {
            if (i >= vector1Size)
            {
                components[i] = vector2.Components[i];
                continue;
            }

            if (i >= vector2Size)
            {
                components[i] = vector1.Components[i];
                continue;
            }

            components[i] = vector1.Components[i] + vector2.Components[i];
        }

        return new Vector(components);
    }

    public static Vector GetSubtractionVectors(Vector vector1, Vector vector2)
    {
        int vector1Size = vector1.GetSize();
        int vector2Size = vector2.GetSize();

        double[] components = new double[Math.Max(vector1Size, vector2Size)];

        for (int i = 0; i < components.Length; i++)
        {
            if (i >= vector1Size)
            {
                components[i] = -1 * vector2.Components[i];
                continue;
            }

            if (i >= vector2Size)
            {
                components[i] = vector1.Components[i];
                continue;
            }

            components[i] = vector1.Components[i] - vector2.Components[i];
        }

        return new Vector(components);
    }

    public static double GetVectorsScalarProduct(Vector vector1, Vector vector2)
    {
        int minSize = Math.Min(vector1.GetSize(), vector2.GetSize());

        double scalar = 0.0;

        for (int i = 0; i < minSize; i++)
        {
            scalar += vector1.Components[i] * vector2.Components[i];
        }

        return scalar;
    }

    public int GetSize()
    {
        return Components.Length;
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", Components) + "}";
    }

    public override int GetHashCode()
    {
        int prime = 15;
        int hash = 1;

        foreach (double component in Components)
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

        if (GetHashCode() != vector.GetHashCode() || GetSize() != vector.GetSize())
        {
            return false;
        }

        double epsilon = 1.0e-10;

        for (int i = 0; i < Components.Length; i++)
        {
            if (Math.Abs(Components[i] - vector.Components[i]) > epsilon)
            {
                return false;
            }
        }

        return true;
    }
}

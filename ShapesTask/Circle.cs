namespace ShapesTask;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public override string ToString()
    {
        return "Круг с радиусом: " + Radius;
    }

    public override int GetHashCode()
    {
        int prime = 15;
        int hash = 1;

        hash = prime * hash + Radius.GetHashCode();

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

        Circle circle = (Circle) obj;

        double epsilon = 1.0e-10;

        return Math.Abs(GetWidth() - circle.GetWidth()) <= epsilon;
    }
}

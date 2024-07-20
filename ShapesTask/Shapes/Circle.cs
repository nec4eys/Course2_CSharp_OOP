namespace ShapesTask.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public override string ToString()
    {
        return "Круг с радиусом: " + Radius + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
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

        Circle circle = (Circle)obj;

        return GetWidth() == circle.GetWidth();
    }
}

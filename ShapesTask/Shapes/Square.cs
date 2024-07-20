namespace ShapesTask.Shapes;

public class Square : IShape
{
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double GetArea()
    {
        return SideLength * SideLength;
    }

    public double GetPerimeter()
    {
        return SideLength * 4;
    }

    public double GetHeight()
    {
        return SideLength;
    }

    public double GetWidth()
    {
        return SideLength;
    }

    public override string ToString()
    {
        return "Квадрат с длиной стороны: " + SideLength + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        int prime = 15;
        int hash = 1;

        hash = prime * hash + SideLength.GetHashCode();

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

        Square square = (Square)obj;

        return SideLength == square.GetWidth();
    }
}

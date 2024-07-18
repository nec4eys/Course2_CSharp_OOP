namespace ShapesTask;

public class Rectangle : IShape
{
    public double Width { get; set; }

    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetPerimeter()
    {
        return (Width + Height) * 2;
    }

    public double GetWidth()
    {
        return Width;
    }

    public override string ToString()
    {
        return "Прямоугольник с шириной: " + Width + " и высотой: " + Height;
    }

    public override int GetHashCode()
    {
        int prime = 15;
        int hash = 1;

        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

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

        Rectangle rectangle = (Rectangle) obj;

        double epsilon = 1.0e-10;

        return Math.Abs(Width - rectangle.GetWidth()) <= epsilon && Math.Abs(Height - rectangle.GetHeight()) <= epsilon;
    }
}

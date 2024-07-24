namespace ShapesTask.Shapes;

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

    public double GetPerimeter()
    {
        return (Width + Height) * 2;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetWidth()
    {
        return Width;
    }

    public override string ToString()
    {
        return "Прямоугольник с шириной: " + Width + " и высотой: " + Height + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        int prime = 17;
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

        Rectangle rectangle = (Rectangle)obj;

        return Width == rectangle.Width && Height == rectangle.Height;
    }
}

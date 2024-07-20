namespace ShapesTask.Shapes;

public class Triangle : IShape
{
    public double X1 { get; set; }

    public double Y1 { get; set; }

    public double X2 { get; set; }

    public double Y2 { get; set; }

    public double X3 { get; set; }

    public double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    private double GetSideLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public double GetArea()
    {
        double sideALength = GetSideLength(X1, Y1, X2, Y2);
        double sideBLength = GetSideLength(X2, Y2, X3, Y3);
        double sideCLength = GetSideLength(X3, Y3, X1, Y1);

        double semiPerimeter = (sideALength + sideBLength + sideCLength) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - sideALength) * (semiPerimeter - sideBLength) * (semiPerimeter - sideCLength));
    }

    public double GetPerimeter()
    {
        double sideALength = GetSideLength(X1, Y1, X2, Y2);
        double sideBLength = GetSideLength(X2, Y2, X3, Y3);
        double sideCLength = GetSideLength(X3, Y3, X1, Y1);

        return sideALength + sideBLength + sideCLength;
    }

    public double GetHeight()
    {
        return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
    }

    public double GetWidth()
    {
        return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
    }

    public override string ToString()
    {
        return $"Треугольник с координатами точек: X1 = {X1}, Y1 = {Y1}, X2 = {X2}, Y2 = {Y2}, X3 = {X3}, Y3 = {Y3}" + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        int prime = 15;
        int hash = 1;

        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

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

        Triangle triangle = (Triangle)obj;

        return X1 == triangle.X1 && Y1 == triangle.Y1 &&
               X2 == triangle.X2 && Y2 == triangle.Y2 &&
               X3 == triangle.X3 && Y3 == triangle.Y3;
    }
}

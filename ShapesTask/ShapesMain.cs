namespace ShapesTask;

internal class ShapesMain
{
    public static IShape GetShapeMaxArea(IShape[] shapes)
    {
        Array.Sort(shapes, new ShapeAreaComparer());

        return shapes[0];
    }

    public static IShape GetShapeSecondMaxPerimeter(IShape[] shapes)
    {
        Array.Sort(shapes, new ShapePerimeterComparer());

        return shapes[1];
    }

    static void Main(string[] args)
    {
        IShape[] shapes =
        {
            new Circle(5.5),
            new Rectangle(8.0, 2.5),
            new Triangle(0.0, 0.0, 3.0, 0.0, 3.0, 3.0),
            new Square(4.0),
            new Circle(7.1)
        };

        Console.WriteLine($"Фигура с максимальной площадью: {GetShapeMaxArea(shapes)}");
        Console.WriteLine($"Фигура со вторым по величине периметром: {GetShapeSecondMaxPerimeter(shapes)}");
    }
}

using ShapesTask.Comparers;
using ShapesTask.Shapes;

namespace ShapesTask;

internal class ShapesMain
{
    public static IShape? GetShapeWithMaxArea(IShape[] shapes)
    {
        if (shapes.Length == 0)
        {
            return null;
        }

        Array.Sort(shapes, new ShapeAreaComparer());

        return shapes[0];
    }

    public static IShape? GetShapeWithSecondMaxPerimeter(IShape[] shapes)
    {
        if (shapes.Length < 2)
        {
            return null;
        }

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

        Console.WriteLine("Фигуры:");

        for (int i = 0; i < shapes.Length; i++)
        {
            Console.WriteLine(shapes[i]);
        }

        Console.WriteLine($"Фигура с максимальной площадью: {GetShapeWithMaxArea(shapes)}");
        Console.WriteLine($"Фигура со вторым по величине периметром: {GetShapeWithSecondMaxPerimeter(shapes)}");
    }
}

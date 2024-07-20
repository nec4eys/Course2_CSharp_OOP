using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public class ShapePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 == null)
        {
            return 1;
        }

        if (shape2 == null)
        {
            return -1;
        }

        double shape1Perimeter = shape1.GetPerimeter();
        double shape2Perimeter = shape2.GetPerimeter();

        return shape2Perimeter.CompareTo(shape1Perimeter);
    }
}

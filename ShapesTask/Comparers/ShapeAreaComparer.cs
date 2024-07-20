using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public class ShapeAreaComparer : IComparer<IShape>
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

        double shape1Area = shape1.GetArea();
        double shape2Area = shape2.GetArea();

        return shape2Area.CompareTo(shape1Area);
    }
}

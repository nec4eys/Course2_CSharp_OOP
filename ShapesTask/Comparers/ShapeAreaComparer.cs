using ShapesTask.Shapes;

namespace ShapesTask.Comparers;

public class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 == null)
        {
            return shape2 == null ? 0 : 1;
        }

        if (shape2 == null)
        {
            return shape1 == null ? 0 : -1;
        }

        double shape1Area = shape1.GetArea();
        double shape2Area = shape2.GetArea();

        return shape1Area.CompareTo(shape2Area);
    }
}

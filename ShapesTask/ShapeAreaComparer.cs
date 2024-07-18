namespace ShapesTask;

public class ShapeAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? x, IShape? y)
    {
        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        double xArea = x.GetArea();
        double yArea = y.GetArea();

        if (xArea > yArea)
        {
            return 1;
        }

        if (xArea < yArea)
        {
            return -1;
        }

        return 0;
    }
}

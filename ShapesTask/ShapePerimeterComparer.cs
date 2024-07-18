namespace ShapesTask;

internal class ShapePerimeterComparer : IComparer<IShape>
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

        double xArea = x.GetPerimeter();
        double yArea = y.GetPerimeter();

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

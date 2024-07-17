namespace RangeTask;

public class Range
{
    public double From { get; set; }

    public double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public double GetLength()
    {
        return To - From;
    }

    public bool IsInside(double number)
    {
        return number >= From && number <= To;
    }

    public Range? GetIntersection(Range range)
    {
        double intersectionFrom = Math.Max(From, range.From);
        double intersectionTo = Math.Min(To, range.To);

        if (intersectionTo <= intersectionFrom)
        {
            return null;
        }

        return new Range(intersectionFrom, intersectionTo);
    }

    public Range[] GetUnion(Range range)
    {
        double intersectionFrom = Math.Max(From, range.From);
        double intersectionTo = Math.Min(To, range.To);

        if (intersectionTo < intersectionFrom)
        {
            return [new Range(From, To), new Range(range.From, range.To)];
        }

        return [new Range(Math.Min(From, range.From), Math.Max(To, range.To))];
    }

    public Range[] GetDifference(Range range)
    {
        if (From >= range.From)
        {
            if (To <= range.To)
            {
                return [];
            }

            return [new Range(Math.Max(From, range.To), To)];
        }

        if (range.To < To)
        {
            return [new Range(From, Math.Min(To, range.From)), new Range(range.To, To)];
        }

        return [new Range(From, Math.Min(To, range.From))];
    }

    public override string ToString()
    {
        return "(" + From + " ; " + To + ")";
    }
}

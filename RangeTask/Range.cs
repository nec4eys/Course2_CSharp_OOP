namespace RangeTask
{
    internal class Range
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

            List<Range> difference = [new Range(From, Math.Min(To, range.From))];

            if (range.To < To)
            {
                difference.Add(new Range(range.To, To));
            }

            return difference.ToArray();
        }

        public override string ToString()
        {
            return From.ToString() + " - " + To.ToString();
        }
    }
}

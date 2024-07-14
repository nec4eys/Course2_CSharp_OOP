using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    internal class Range
    {
        private double From { get; set; }
        private double To { get; set; }

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
            return number - From >= 0 && To - number >= 0;
        }

        public Range GetRangesIntersection(Range anotherRange)
        {
            double intersectionFrom = Math.Max(From, anotherRange.From);
            double intersectionTo = Math.Min(To, anotherRange.To);

            if (intersectionTo - intersectionFrom <= 0)
            {
                return null;
            }

            return new Range(intersectionFrom, intersectionTo);
        }

        public Range[] GetRangesUnion(Range anotherRange)
        {
            Range intersectionRange = GetRangesIntersection(anotherRange);

            if (intersectionRange == null)
            {
                if (From != anotherRange.To && To != anotherRange.From)
                {
                    return [this, anotherRange];
                }
            }

            return [new Range(Math.Min(From, anotherRange.From), Math.Max(To, anotherRange.To))];
        }

        public Range[] GetRangesDifference(Range anotherRange)
        {
            Range intersectionRange = GetRangesIntersection(anotherRange);

            if (intersectionRange == null)
            {
                return [this, anotherRange];
            }

            if ((From == anotherRange.From && To == anotherRange.To) || (intersectionRange.From == From && intersectionRange.To == To))
            {
                return [];
            }

            if (intersectionRange.From == anotherRange.From && intersectionRange.To == anotherRange.To)
            {
                if (From == anotherRange.From)
                {
                    return [new Range(intersectionRange.To, To)];
                }

                if (To == anotherRange.To)
                {
                    return [new Range(From, intersectionRange.From)];
                }

                return [new Range(From, intersectionRange.From), new Range(intersectionRange.To, To)];
            }

            if (IsInside(intersectionRange.To) && intersectionRange.To != To)
            {
                return [new Range(intersectionRange.To, To)];
            }

            return [new Range(From, intersectionRange.From)];
        }
    }
}

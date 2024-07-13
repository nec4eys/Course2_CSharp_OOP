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

        public Range GetIntersection(Range anotherRange) // поменять название функции
        {
            double intersectionFrom = Math.Max(From, anotherRange.From);
            double intersectionTo = Math.Min(To, anotherRange.To);

            if (intersectionTo - intersectionFrom <= 0)
            {
                return null;
            }

            return new Range(intersectionFrom, intersectionTo);
        }

        public Range[] GetUnification(Range anotherRange) // поменять название функции
        {
            Range intersectionRange = GetIntersection(anotherRange);

            if (intersectionRange == null)
            {
                if (From != anotherRange.From && To != anotherRange.To)
                {
                    return [this, anotherRange];
                }
            }

            return [new Range(Math.Min(From, anotherRange.From), Math.Max(To, anotherRange.To))];
        }

        public Range[] GetDifference(Range anotherRange) // поменять название функции
        {
            Range intersectionRange = GetIntersection(anotherRange);

            if (intersectionRange == null)
            {
                return [this, anotherRange];
            }

            if ((From == anotherRange.From && To == anotherRange.To) || intersectionRange.Equals(this))
            {
                return [];
            }

            if (intersectionRange.Equals(anotherRange))
            {
                return [new Range(From, intersectionRange.From), new Range(intersectionRange.To, To)];
            }

            if (IsInside(intersectionRange.To))
            {
                return [new Range(intersectionRange.To, To)];
            }

            return [new Range(From, intersectionRange.From)];
        }
    }
}

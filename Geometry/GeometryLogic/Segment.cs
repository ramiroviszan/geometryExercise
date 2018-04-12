using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLogic
{
    public class Segment
    {
        private Vector start;
        private Vector end;

        public Segment(Vector segmentStart, Vector segmentEnd)
        {
            start = segmentStart;
            end = segmentEnd;

            if(Length() == 0)
            {
                throw new ZeroSegmentException();
            }
        }

        public bool IsHorizontal()
        {
            return start.X != end.X && start.Y == end.Y;
        }


        public bool IsVertical()
        {
            return start.X == end.X && start.Y != end.Y;
        }

        public int Length()
        {
            int result = 0;
            if (IsHorizontal())
            {
                result = (int) Math.Abs(end.X - start.X);
            }
            else if (IsVertical())
            {
                result = (int) Math.Abs(end.Y - start.Y);
            }
            return result;
        }

        public bool Intersects(Segment segment)
        {
            Vector a = end - start;
            Vector b = segment.start - segment.end;
            Vector c = start - segment.start;

            float alphaNumerator = b.Y * c.X - b.X * c.Y;
            float betaNumerator = a.X * c.Y - a.Y * c.X;
            float denominator = a.Y * b.X - a.X * b.Y;

            bool intersect = !CheckForCollinearity(denominator);
            intersect &= CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);

            return intersect;
        }

        public Vector GetIntersection(Segment segment)
        {
            Vector a = end - start;
            Vector b = segment.start - segment.end;
            Vector c = start - segment.start;

            float alphaNumerator = b.Y * c.X - b.X * c.Y;
            float betaNumerator = a.X * c.Y - a.Y * c.X;
            float denominator = a.Y * b.X - a.X * b.Y;

            bool intersect = !CheckForCollinearity(denominator);
            intersect &= CompareNumeratorWithDenominator(alphaNumerator, denominator);
            intersect &= CompareNumeratorWithDenominator(betaNumerator, denominator);

            if (!intersect)
            {
                throw new SegmentsDoNotIntersectException();
            }
            return GetIntersectedVector(alphaNumerator, denominator);
        }

        private bool CheckForCollinearity(float denominator)
        {
            return denominator == 0;
        }

        private bool CompareNumeratorWithDenominator(float numerator, float denominator)
        {
            float division = numerator / denominator;
            return division >= 0 && division <= 1;
        }

        private Vector GetIntersectedVector(float alphaNumerator, float denominator)
        {
            float alphaOfIntersection = alphaNumerator / denominator;
            float x = start.X + alphaOfIntersection * (end.X - start.X);
            float y = start.Y + alphaOfIntersection * (end.Y - start.Y);
            return new Vector(x, y);
        }

    }
}

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

        public bool DoesIntersect(Segment segment)
        {
            Vector a = segment.end - segment.start;
            Vector b = start - end;
            Vector c = segment.start - start;

            float alphaNumerator = b.Y * c.X - b.X * c.Y;
            float betaNumerator = a.X * c.Y - a.Y * c.X;
            float denominator = a.Y * b.X - a.X * b.Y;

            bool intersect = denominator != 0;
            intersect &= NumeratorAgainstDenominatorGreaterThanZero(alphaNumerator, denominator);
            intersect |= NumeratorAgainstDenominatorNotGreaterThanZero(alphaNumerator, denominator);
            intersect &= NumeratorAgainstDenominatorGreaterThanZero(betaNumerator, denominator);
            intersect |= NumeratorAgainstDenominatorNotGreaterThanZero(betaNumerator, denominator);

            return intersect;
        }

        private bool NumeratorAgainstDenominatorGreaterThanZero(float numerador, float denominator)
        {
            return !(denominator > 0 && (numerador < 0 || numerador > denominator));
        }

        private bool NumeratorAgainstDenominatorNotGreaterThanZero(float numerador, float denominator)
        {
            return !(numerador > 0 || numerador < denominator);
        }

        public Vector GetIntersection(Segment segment)
        {
            Vector a = segment.end - segment.start;
            Vector b = start - end;
            Vector c = segment.start - start;

            float alphaNumerator = b.Y * c.X - b.X * c.Y;
            float betaNumerator = a.X * c.Y - a.Y * c.X;
            float denominator = a.Y * b.X - a.X * b.Y;

            bool intersect = denominator != 0;
            intersect &= NumeratorAgainstDenominatorGreaterThanZero(alphaNumerator, denominator);
            intersect |= NumeratorAgainstDenominatorNotGreaterThanZero(alphaNumerator, denominator);
            intersect &= NumeratorAgainstDenominatorGreaterThanZero(betaNumerator, denominator);
            intersect |= NumeratorAgainstDenominatorNotGreaterThanZero(betaNumerator, denominator);

            if(intersect)
            {
                float alphaOfIntersection = alphaNumerator / denominator; 
                float x = segment.start.X + alphaOfIntersection * (segment.end.X - segment.start.X);
                float y = segment.start.Y + alphaOfIntersection * (segment.end.Y - segment.start.Y);
                return new Vector(x, y);
            }
            throw new SegmentsDoNotIntersectException();
        }
    }
}

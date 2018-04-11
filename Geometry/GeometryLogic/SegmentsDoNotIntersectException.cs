using System;
using System.Runtime.Serialization;

namespace GeometryLogic
{
    public class SegmentsDoNotIntersectException : Exception
    {
        public SegmentsDoNotIntersectException()
        {
        }

        public SegmentsDoNotIntersectException(string message) : base(message)
        {
        }

        public SegmentsDoNotIntersectException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SegmentsDoNotIntersectException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
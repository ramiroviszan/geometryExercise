using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLogic;

namespace GeometryLogic.Test
{
    [TestClass]
    public class SegmentTest
    {

        [TestMethod]
        public void NewHorizontalSegmentTest()
        {
            Segment segment = new Segment(new Vector(0,0), new Vector(2, 0));
            Assert.IsTrue(segment.IsHorizontal());
        }

        [TestMethod]
        public void NewVerticalSegmentTest()
        {
            Segment segment = new Segment(new Vector(0, 0), new Vector(0, 2));
            Assert.IsTrue(segment.IsVertical());
        }

        [TestMethod]
        public void HorizontalSegmentLengthTest()
        {
            Segment segment = new Segment(new Vector(0, 0), new Vector(5, 0));
            Assert.AreEqual(5, segment.Length());
        }

        [TestMethod]
        public void VerticalSegmentLengthTest()
        {
            Segment segment = new Segment(new Vector(0, 0), new Vector(0, 5));
            Assert.AreEqual(5, segment.Length());
        }

        [TestMethod]
        [ExpectedException(typeof(ZeroSegmentException))]
        public void NewSegmentZeroLengthTest()
        {
            Segment segment = new Segment(new Vector(0, 0), new Vector(0, 0));
        }


        [TestMethod]
        public void NewSegmentIntesectsOldOneTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(0, -5), new Vector(0, 5));
            Assert.IsTrue(newSegment.Intersects(oldSegment));
        }

        [TestMethod]
        public void NewSegmentDoesNotIntersectOldOneTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(6, -5), new Vector(6, 5));
            Assert.IsTrue(!newSegment.Intersects(oldSegment));
        }


        [TestMethod]
        public void GetSegmentsIntersectionTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(0, -5), new Vector(0, 5));
            Assert.AreEqual(new Vector(0, 0), newSegment.GetIntersection(oldSegment));
        }

        [TestMethod]
        public void GetSegmentsIntersectionInTShapeTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(5, -5), new Vector(5, 5));
            Assert.AreEqual(new Vector(5, 0), newSegment.GetIntersection(oldSegment));
        }

        [TestMethod]
        public void GetSegmentsIntersectionInCornerShapeTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(5, 0), new Vector(5, 5));
            Assert.AreEqual(new Vector(5, 0), newSegment.GetIntersection(oldSegment));
        }

        [TestMethod]
        [ExpectedException(typeof(SegmentsDoNotIntersectException))]
        public void FailedSegmentsIntersectionTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(6, -5), new Vector(6, 5));
            newSegment.GetIntersection(oldSegment);
        }

        [TestMethod]
        [ExpectedException(typeof(SegmentsDoNotIntersectException))]
        public void CollinearSegmentsIntersectionTest()
        {
            Segment oldSegment = new Segment(new Vector(-5, 0), new Vector(5, 0));
            Segment newSegment = new Segment(new Vector(-5, 1), new Vector(6, 1));
            newSegment.GetIntersection(oldSegment);
        }
    }
}

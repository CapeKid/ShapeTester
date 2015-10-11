using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer.Tests
{
    [TestClass]
    public class RectangleMathHelperTest
    {
        private IRectangleMathHelper RectangleMathHelper { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            RectangleMathHelper = new RectangleMathHelper();
        }

        #region DoesEitherRectangleOverlapTheOther
        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_DoesNotOverlapAtAll_ReturnsFalse()
        {
            //0000
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0022
            0022
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(2, 2, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }


        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_XDoesntOverlap_TopOfRect1YWithinRect2YArea_ReturnsFalse()
        {
            //0001
            /*Picture of rectangle location
            0011
            0011
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(2, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2200
            2200
            2200
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 1, 2);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_XDoesntOverlap_TopOfRect2YWithinRect1YArea_ReturnsFalse()
        {
            //0010
            /*Picture of rectangle location
            0000
            1100
            1100
            1100
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 1, 2);

            /*Picture of rectangle location
            0022
            0022
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(2, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect2WithinRect1XArea_YDoesntOverlap_ReturnsFalse()
        {
            //0100
            /*Picture of rectangle location
            0000
            0000
            1110
            1110
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 2, 2, 1);

            /*Picture of rectangle location
            0220
            0220
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect1WithinRect2XArea_YDoesntOverlap_ReturnsFalse()
        {
            //1000
            /*Picture of rectangle location
            0110
            0110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 1);

            /*Picture of rectangle location
            0000
            0000
            2220
            2220
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 2, 2, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_XDoesntOverlap_BothYOverlapEachOther_ReturnsFalse()
        {
            //0011
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0022
            0022
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(2, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect2WithinRect1XArea_TopOfRect2YWithinRect1YArea_ReturnsTrue()
        {
            //0110
            /*Picture of rectangle location
            0000
            1110
            1010
            1110
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 2, 2);

            /*Picture of rectangle location
            0222
            0202
            0222
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 2, 2);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_BothXOverlapEachOther_YDoesntOverlap_ReturnsFalse()
        {
            //1100
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            0000
            2200
            2200
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 2, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect1WithinRect2XArea_TopOfRect2YWithinRect1YArea_ReturnsTrue()
        {
            //1001
            /*Picture of rectangle location
            0110
            0110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2220
            2220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 2, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect2WithinRect1XArea_TopOfRect1YWithinRect2YArea_ReturnsTrue()
        {
            //0101
            /*Picture of rectangle location
            1110
            1110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 2, 1);

            /*Picture of rectangle location
            0000
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 1, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }


        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect1WithinRect2XArea_TopOfRect1WithinRect2YArea_ReturnsTrue()
        {
            //1010
            /*Picture of rectangle location
            0000
            0110
            0110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 1, 1);

            /*Picture of rectangle location
            2220
            2220
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect2WithinRect1XArea_BothYOverlapEachOther_ReturnsTrue()
        {
            //0111
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0220
            0220
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_BothXOverlapEachOther_TopOfRect1YWithinRect2YArea_ReturnsTrue()
        {
            //1110
            /*Picture of rectangle location
            0000
            1100
            1100
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 1, 1);

            /*Picture of rectangle location
            2200
            2200
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_BothXOverlapEachOther_TopOfRect2YWithinRect1YArea_ReturnsTrue()
        {
            //1101
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2200
            2200
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_LeftOfRect1WithinRect2XArea_BothYOverlapEachOther_ReturnsTrue()
        {
            //1011
            /*Picture of rectangle location
            0110
            0110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 1);

            /*Picture of rectangle location
            2220
            2220
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_BothXOverlapEachOther_BothYOverlapEachOther_ReturnsTrue()
        {
            //1111
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            2200
            2200
            0000
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isOverlapping);
        }

        [TestMethod]
        public void DoesEitherRectangleOverlapTheOther_OneContainsTheOther_ReturnsFalse()
        {
            /*Picture of rectangle location
            1111
            1001
            1001
            1111
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 4, 4);

            /*Picture of rectangle location
            0000
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 1, 1, 1);

            var isOverlapping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isOverlapping);
        }
        #endregion

        #region DoesEitherRectangleContainTheOther
        [TestMethod]
        public void DoesEitherRectangleContainTheOther_RectOneContainsRectTwo_ReturnsTrue()
        {
            /*Picture of rectangle location
            1111
            1001
            1001
            1111
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 4, 4);

            /*Picture of rectangle location
            0000
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 1, 1, 1);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_RectTwoContainsRectOne_ReturnsTrue()
        {
            /*Picture of rectangle location
            0000
            0110
            0110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 1, 1);

            /*Picture of rectangle location
            2222
            2002
            2002
            2222
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 4, 4); 

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_LeftSideRect1ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            1110
            1110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 2, 1);

            /*Picture of rectangle location
            0222
            0202
            0202
            0222
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 3, 4);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_TopSideRect1ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0110
            0110
            0110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 2);

            /*Picture of rectangle location
            0000
            2222
            2002
            2222
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 4, 3);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_RightSideRect1ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            0111
            0111
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 2, 1);

            /*Picture of rectangle location
            2220
            2020
            2020
            2220
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 3);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_BottomSideRect1ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            0110
            0110
            0110
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 1, 2);

            /*Picture of rectangle location
            2222
            2002
            2222
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 3, 2);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_LeftSideRect2ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            1110
            1110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 2, 1);

            /*Picture of rectangle location
            0222
            0202
            0202
            0222
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 2, 3);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle2, rectangle1);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_TopSideRect2ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0110
            0110
            0110
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 2);

            /*Picture of rectangle location
            0000
            2222
            2002
            2222
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 3, 2);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle2, rectangle1);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_RightSideRect2ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            0111
            0111
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 2, 1);

            /*Picture of rectangle location
            2220
            2020
            2020
            2220
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 3);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle2, rectangle1);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_BottomSideRect2ExtendsPast_ReturnsFalse()
        {
            /*Picture of rectangle location
            0000
            0110
            0110
            0110
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 1, 1, 2);

            /*Picture of rectangle location
            2222
            2002
            2222
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 3, 2);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle2, rectangle1);
            Assert.IsFalse(isContained);
        }

        [TestMethod]
        public void DoesEitherRectangleContainTheOther_NoOverlapAtAll_ReturnsFalse()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            0000
            0022
            0022
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(2, 2, 1, 1);

            var isContained = RectangleMathHelper.DoesEitherRectangleContainTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isContained);
        }
        #endregion

        #region IsEitherRectangleAdjacentToTheOther
        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_LeftSideRect1Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2220
            2220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 2, 1);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_TopSideRect1Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0220
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 2);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_RightSideRect1Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            0110
            0110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2220
            2220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 1);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_BottomSideRect1Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            0000
            1100
            1100
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 1, 1);

            /*Picture of rectangle location
            0220
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 2);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle1, rectangle2);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_LeftSideRect2Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2220
            2220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 1, 2, 1);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle2, rectangle1);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_TopSideRect2Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0220
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 2);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle2, rectangle1);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_RightSideRect2Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            0110
            0110
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(1, 0, 1, 1);

            /*Picture of rectangle location
            0000
            2220
            2220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(0, 0, 2, 1);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle2, rectangle1);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_BottomSideRect2Adjacent_ReturnsTrue()
        {
            /*Picture of rectangle location
            0000
            1100
            1100
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 1, 1, 1);

            /*Picture of rectangle location
            0220
            0220
            0220
            0000
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(1, 0, 1, 2);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle2, rectangle1);
            Assert.IsTrue(isAdjacent);
        }

        [TestMethod]
        public void IsEitherRectangleAdjacentToTheOther_NoSideAdjacent_ReturnsFalse()
        {
            /*Picture of rectangle location
            1100
            1100
            0000
            0000
            */
            DoubleRectangle rectangle1 = new DoubleRectangle(0, 0, 1, 1);

            /*Picture of rectangle location
            0000
            0000
            0022
            0022
            */
            DoubleRectangle rectangle2 = new DoubleRectangle(2, 2, 1, 1);

            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(rectangle1, rectangle2);
            Assert.IsFalse(isAdjacent);
        }
        #endregion
    }
}

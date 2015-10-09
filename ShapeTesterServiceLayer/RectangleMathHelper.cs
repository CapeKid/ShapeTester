using System;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer
{
    /// <summary>
    /// Helper class to do math that c# libraries cannot
    /// </summary>
    public class RectangleMathHelper : IRectangleMathHelper
    {
        /// <summary>
        /// Check that two double precision rectangles overlap with each other
        /// </summary>
        /// <param name="rect1">The first rectangle</param>
        /// <param name="rect2">The second rectangle</param>
        /// <returns>The rectangles overlap</returns>
        public bool DoesEitherRectangleOverlapTheOther(DoubleRectangle rect1, DoubleRectangle rect2)
        {
            bool leftOfRect1InsideRect2Width = ValuesOverlap(rect1.X, rect2.X, rect2.X + rect2.Width);
            bool leftOfRect2InsideRect1Width = ValuesOverlap(rect2.X, rect1.X, rect1.X + rect1.Width);
            bool xOverlap = leftOfRect1InsideRect2Width || leftOfRect2InsideRect1Width;

            bool topOfRect1InsideRect2Height = ValuesOverlap(rect1.Y, rect2.Y, rect2.Y + rect2.Height);
            bool topOfRect2InsideRect1Height = ValuesOverlap(rect2.Y, rect1.Y, rect1.Y + rect2.Height);
            bool yOverlap = topOfRect1InsideRect2Height || topOfRect2InsideRect1Height;

            bool rectanglesIntersect = xOverlap && yOverlap;

            return rectanglesIntersect;
        }

        private bool ValuesOverlap(double value, double min, double max)
        {
            return (value >= min) && (value <= max);
        }

        /// <summary>
        /// True if either rectangle is entirely contained within the other rectangle
        /// </summary>
        /// <param name="rect1">The first rectangle</param>
        /// <param name="rect2">The second rectangle</param>
        /// <returns>At least one rectangle is contained within the other</returns>
        public bool DoesEitherRectangleContainTheOther(DoubleRectangle rect1, DoubleRectangle rect2)
        {
            return ContainedWithin(rect1, rect2) || ContainedWithin(rect2, rect1);
        }

        /// <summary>
        /// True if small rectangle is entirely contained within the larger rectangle
        /// </summary>
        /// <param name="largerRectangle">The larger rectangle</param>
        /// <param name="smallerRectangle">The smaller rectangle</param>
        /// <returns>True if small rectangle is entirely contained within the larger rectangle, false otherwise</returns>
        private bool ContainedWithin(DoubleRectangle largerRectangle, DoubleRectangle smallerRectangle)
        {
            bool lowerLeftCheck = largerRectangle.LowerLeft.X < smallerRectangle.LowerLeft.X && largerRectangle.LowerLeft.Y < smallerRectangle.LowerLeft.Y;
            bool upperLeftCheck = largerRectangle.UpperLeft.X < smallerRectangle.UpperLeft.X && largerRectangle.UpperLeft.Y > smallerRectangle.UpperLeft.Y;

            bool lowerRightCheck = largerRectangle.LowerRight.X > smallerRectangle.LowerRight.X && largerRectangle.LowerRight.Y < smallerRectangle.LowerRight.Y;
            bool upperRightCheck = largerRectangle.UpperRight.X > smallerRectangle.UpperRight.X && largerRectangle.UpperRight.Y > smallerRectangle.UpperRight.Y;

            return lowerLeftCheck && upperLeftCheck && lowerRightCheck && upperRightCheck;
        }

        /// <summary>
        /// True if either rectangle is adjacent to the other rectangle
        /// </summary>
        /// <param name="rect1">The first rectangle</param>
        /// <param name="rect2">The second rectangle</param>
        /// <returns>At least one rectangle is adjacent to the other rectangle</returns>
        public bool IsEitherRectangleAdjacentToTheOther(DoubleRectangle rect1, DoubleRectangle rect2)
        {
            bool overlapsWithRect2Left = rect1.X.Equals(rect2.X) || rect1.RightSideX.Equals(rect2.X);
            bool overlapsWithRect2Right = rect1.X.Equals(rect2.RightSideX) || rect1.RightSideX.Equals(rect2.RightSideX);

            bool overlapsWithRect2Bottom = rect1.Y.Equals(rect2.Y) || rect1.TopY.Equals(rect2.Y);
            bool overlapsWithRect2Top = rect1.Y.Equals(rect2.TopY) || rect1.TopY.Equals(rect2.TopY);

            return overlapsWithRect2Left || overlapsWithRect2Right || overlapsWithRect2Bottom || overlapsWithRect2Top;
        }
    }
}
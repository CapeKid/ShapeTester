using System;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer
{
    /// <summary>
    /// Helper class to do math that c# libraries cannot
    /// </summary>
    public class DoubleRectangleFactory : IDoubleRectangleFactory
    {
        /// <summary>
        /// Used to construct a rectangle using the canvas coordinate system
        /// </summary>
        /// <param name="startX">Origin point of the click on the X axis</param>
        /// <param name="startY">Origin point of the click on the Y axis</param>
        /// <param name="drawWidth">The width of the object in the web layer (may be negative)</param>
        /// <param name="drawHeight">The height of the object in the web layer (may be negative)</param>
        public DoubleRectangle CreateDoubleRectangleFromWebCoordinates(int startX, int startY, int drawWidth, int drawHeight)
        {
            var x = drawWidth > 0 ? startX : startX + drawWidth;
            var y = drawHeight > 0 ? startY : startY + drawHeight;
            var width = Math.Abs(drawWidth);
            var height = Math.Abs(drawHeight);
            var doubleRectangle = new DoubleRectangle(x, y, width, height);
            return doubleRectangle;
        }
    }
}
using System.Windows;
using System;
namespace ShapeTesterServiceLayer.SharedObjects
{
    /// <summary>
    /// Double precision rectangle
    /// </summary>
    public class DoubleRectangle
    {
        public DoubleRectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Used to construct a rectangle using the canvas coordinate system
        /// </summary>
        /// <param name="startX">Origin point of the click on the X axis</param>
        /// <param name="startY">Origin point of the click on the Y axis</param>
        /// <param name="drawWidth">The width of the object in the web layer (may be negative)</param>
        /// <param name="drawHeight">The height of the object in the web layer (may be negative)</param>
        public DoubleRectangle(int startX, int startY, int drawWidth, int drawHeight)
        {
            //TODO: Move to converter?
            X = drawWidth > 0 ? startX : startX + drawWidth;
            Y = drawHeight > 0 ? startY : startY + drawHeight;

            Width = Math.Abs(drawWidth);
            Height = Math.Abs(drawHeight);
        }

        //The lower left most x coordinate
        public double X { get; set; }
        //The lower left most y coordinate
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double RightSideX => X + Width;

        public double BotY => Y + Height;

        public Point UpperLeft => new Point(X, Y + Height);

        public Point LowerLeft => new Point(X, Y);

        public Point UpperRight => new Point(X + Width, Y + Height);

        public Point LowerRight => new Point(X + Width, Y);
    }
}

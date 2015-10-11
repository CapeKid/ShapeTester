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

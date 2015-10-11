using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer.Interfaces
{
    public interface IDoubleRectangleFactory
    {
        DoubleRectangle CreateDoubleRectangleFromWebCoordinates(int startX, int startY, int drawWidth, int drawHeight);
    }
}

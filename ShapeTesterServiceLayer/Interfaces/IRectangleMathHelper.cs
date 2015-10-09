using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterServiceLayer.Interfaces
{
    public interface IRectangleMathHelper
    {
        bool DoesEitherRectangleOverlapTheOther(DoubleRectangle rect1, DoubleRectangle rect2);
        
        bool DoesEitherRectangleContainTheOther(DoubleRectangle rect1, DoubleRectangle rect2);

        bool IsEitherRectangleAdjacentToTheOther(DoubleRectangle rect1, DoubleRectangle rect2);
    }
}

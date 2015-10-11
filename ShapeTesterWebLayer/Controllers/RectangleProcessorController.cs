using System.Web.Mvc;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;
using ShapeTesterWebLayer.ViewModel;

namespace ShapeTesterWebLayer.Controllers
{
    public class RectangleProcessorController : Controller
    {
        IRectangleMathHelper RectangleMathHelper { get; }

        public RectangleProcessorController(IRectangleMathHelper rectangleMathHelper)
        {
            RectangleMathHelper = rectangleMathHelper;
        }

        public ActionResult TestOverlap(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.StartX,
                rect1.StartY,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.StartX,
                rect2.StartY,
                rect2.Width,
                rect2.Height);
            
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);

            return Content(isOverlaping.ToString());
        }

        public ActionResult TestAdjacent(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.StartX,
                rect1.StartY,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.StartX,
                rect2.StartY,
                rect2.Width,
                rect2.Height);
            
            var isAdjecent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);

            return Content(isAdjecent.ToString());
        }

        public ActionResult TestContain(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.StartX,
                rect1.StartY,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.StartX,
                rect2.StartY,
                rect2.Width,
                rect2.Height);
            
            var isContain = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);
            
            return Content(isContain.ToString());
        }

        
        public ActionResult TestAll(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.StartX,
                rect1.StartY,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.StartX,
                rect2.StartY,
                rect2.Width,
                rect2.Height);

            var isOverlap = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);
            var isContain = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);
            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);
            
            return Json(new {
                isOverlap = isOverlap,
                isContain = isContain,
                isAdjacent = isAdjacent
            });
        }
    }
}
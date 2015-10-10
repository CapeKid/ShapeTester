using System;
using System.Web.Mvc;
using ShapeTesterServiceLayer;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;
using ShapeTesterWebLayer.ViewModel;

namespace ShapeTesterWebLayer.Controllers
{
    public class RectangleProcessorController : Controller
    {
        RectangleMathHelper RectangleMathHelper { get; }

        public RectangleProcessorController(RectangleMathHelper rectangleMathHelper)
        {
            RectangleMathHelper = rectangleMathHelper;
        }

        public ActionResult TestOverlap(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.X,
                rect1.Y,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.X,
                rect2.Y,
                rect2.Width,
                rect2.Height);
            
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }

        public ActionResult TestAdjacent(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.X,
                rect1.Y,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.X,
                rect2.Y,
                rect2.Width,
                rect2.Height);
            
            var isAdjecent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isAdjecent.ToString());
        }

        public ActionResult TestContain(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.X,
                rect1.Y,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.X,
                rect2.Y,
                rect2.Width,
                rect2.Height);
            
            var isContain = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isContain.ToString());
        }

        public ActionResult TestAll(Rectangle rect1, Rectangle rect2)
        {
            var doubleRectangle1 = new DoubleRectangle(
                rect1.X,
                rect1.Y,
                rect1.Width,
                rect1.Height);

            var doubleRectangle2 = new DoubleRectangle(
                rect2.X,
                rect2.Y,
                rect2.Width,
                rect2.Height);

            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);
            var isContain = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);
            var isAdjacent = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(string.Format("overlap: {0}\r\ncontain: {1}\r\nadjacent: {2}", isOverlaping, isContain, isAdjacent));
        }
        
    }
}
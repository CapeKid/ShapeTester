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

        public ActionResult ProcessRectangles(Rectangle rect1, Rectangle rect2)
        {
            //TODO: Maybe add some converter here
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

            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }
    }
}
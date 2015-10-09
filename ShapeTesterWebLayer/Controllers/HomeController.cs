using System;
using System.Web.Mvc;
using ShapeTesterServiceLayer;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;

namespace ShapeTesterWebLayer.Controllers
{
    public class HomeController : Controller
    {
        RectangleMathHelper RectangleMathHelper { get; }

        public HomeController(RectangleMathHelper rectangleMathHelper)
        {
            RectangleMathHelper = rectangleMathHelper;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult CollideTest(string rectangleOne, string rectangleTwo)
        {
            var doubleRectangle1 = new DoubleRectangle(0, 0, 1, 1);
            var doubleRectangle2 = new DoubleRectangle(2, 2, 2, 2);
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }

        public ActionResult ContainTest(string rectangleOne, string rectangleTwo)
        {
            var doubleRectangle1 = new DoubleRectangle(0, 0, 5, 5);
            var doubleRectangle2 = new DoubleRectangle(1, 1, 1, 1);
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);


            //Present it to the user
            return Content(isOverlaping.ToString());
        }

        public ActionResult AdjacentTest(string rectangleOne, string rectangleTwo)
        {
            var doubleRectangle1 = new DoubleRectangle(0, 0, 2, 2);
            var doubleRectangle2 = new DoubleRectangle(1, 1, 1, 1);
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }
    }
}
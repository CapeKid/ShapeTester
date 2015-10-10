using System;
using System.Web.Mvc;
using ShapeTesterServiceLayer;
using ShapeTesterServiceLayer.Interfaces;
using ShapeTesterServiceLayer.SharedObjects;
using ShapeTesterWebLayer.ViewModel;

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

        public ActionResult RectOne(Rectangle rect1)
        {
            return Content(string.Format("" + rect1.X));
        }

        public ActionResult CollideTest(string rectangleOne, string rectangleTwo)
        {
            string[] rect1Info = rectangleOne.Split(',');
            var doubleRectangle1 = new DoubleRectangle(
                double.Parse(rect1Info[0]), 
                double.Parse(rect1Info[1]),
                double.Parse(rect1Info[2]),
                double.Parse(rect1Info[3]));

            string[] rect2Info = rectangleTwo.Split(',');
            var doubleRectangle2 = new DoubleRectangle(
                double.Parse(rect2Info[0]),
                double.Parse(rect2Info[1]),
                double.Parse(rect2Info[2]),
                double.Parse(rect2Info[3]));
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleOverlapTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }

        public ActionResult ContainTest(string rectangleOne, string rectangleTwo)
        {
            string[] rect1Info = rectangleOne.Split(',');
            var doubleRectangle1 = new DoubleRectangle(
                double.Parse(rect1Info[0]),
                double.Parse(rect1Info[1]),
                double.Parse(rect1Info[2]),
                double.Parse(rect1Info[3]));

            string[] rect2Info = rectangleTwo.Split(',');
            var doubleRectangle2 = new DoubleRectangle(
                double.Parse(rect2Info[0]),
                double.Parse(rect2Info[1]),
                double.Parse(rect2Info[2]),
                double.Parse(rect2Info[3]));
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.DoesEitherRectangleContainTheOther(doubleRectangle1, doubleRectangle2);


            //Present it to the user
            return Content(isOverlaping.ToString());
        }

        public ActionResult AdjacentTest(string rectangleOne, string rectangleTwo)
        {
            string[] rect1Info = rectangleOne.Split(',');
            var doubleRectangle1 = new DoubleRectangle(
                double.Parse(rect1Info[0]),
                double.Parse(rect1Info[1]),
                double.Parse(rect1Info[2]),
                double.Parse(rect1Info[3]));

            string[] rect2Info = rectangleTwo.Split(',');
            var doubleRectangle2 = new DoubleRectangle(
                double.Parse(rect2Info[0]),
                double.Parse(rect2Info[1]),
                double.Parse(rect2Info[2]),
                double.Parse(rect2Info[3]));
            //Do some AddingNumbers Work
            var isOverlaping = RectangleMathHelper.IsEitherRectangleAdjacentToTheOther(doubleRectangle1, doubleRectangle2);

            //Present it to the user
            return Content(isOverlaping.ToString());
        }
    }
}
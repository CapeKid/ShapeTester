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

        public ActionResult Test(Rectangle rectangle)
        {
            return Content(string.Format("test"));
        }
    }
}
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
        public HomeController()
        {
 
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
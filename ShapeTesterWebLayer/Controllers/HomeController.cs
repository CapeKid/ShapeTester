﻿using System.Web.Mvc;

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
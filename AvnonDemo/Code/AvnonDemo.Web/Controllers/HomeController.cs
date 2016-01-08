using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AvnonDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml", "~/Views/Shared/_LayoutCustomer.cshtml");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppLabs.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Simple()
        {
            ViewBag.Message = "Simple C# and web application exercises";

            return View();
        }

        public ActionResult Moderate()
        {
            ViewBag.Message = "Moderate to difficult C# and web application exercises";

            return View();
        }

        public ActionResult Complex()
        {
            ViewBag.Message = "Complex C# and web applications, including mastery projects";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Complex C# and web applications, including mastery projects";

            return View();
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamileLMS.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("Teacher"))
                {
                    return RedirectToAction("Index", "Teacher");
                }
                if (User.IsInRole("Student"))
                {
                    return RedirectToAction("Index", "Student");
                }
                if (User.IsInRole("Parent"))
                {
                    return RedirectToAction("Index", "Parent");
                }
            }

            
            return View();
        }

    
    }
}
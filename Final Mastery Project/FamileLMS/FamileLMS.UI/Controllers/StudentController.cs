using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamileLMS.Data;
using FamileLMS.Models.Views;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace FamileLMS.UI.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository repository = new StudentRepository();
        //
        // GET: /Student/
        public ActionResult Index()
        {
            var model = repository.GetListofClassesWithGrades(User.Identity.GetUserId());
            return View(model);
        }

        [HttpPost]
        public ActionResult Grades(int ClassID)
        {
            var model = repository.GetStudentAssignmentGradesbyClass(User.Identity.GetUserId(), ClassID);
            ViewBag.ClassID = ClassID;
            return View(model);
        }
	}
}
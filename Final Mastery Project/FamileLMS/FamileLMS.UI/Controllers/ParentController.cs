using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamileLMS.Data;
using FamileLMS.Models.Requests;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using FamileLMS.Models;

namespace FamileLMS.UI.Controllers
{
    public class ParentController : Controller
    {
        private ParentRepository repository=new ParentRepository();


        public ActionResult Index()
        {
            var model = repository.GetStudents(User.Identity.GetUserId());
            
            return View(model);
        }
        private StudentRepository studentrepo=new StudentRepository();

        [HttpPost]
        public ActionResult ChildClasses(string UserID)
        {
            var model = studentrepo.GetListofClassesWithGrades(UserID);
            foreach (var item in model)
            {
                item.UserID = UserID;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Grades(ParentGradeRequest request)//compare to StudentController Grades
        {
            var model = repository.GetStudentAssignmentGradesbyClass(request.ChildID, request.ClassID);
            ViewBag.ClassID = request.ClassID;
            ViewBag.StudentID = request.ChildID; //must cast in View
            return View(model);
        }
	}

}
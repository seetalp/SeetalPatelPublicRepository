using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamileLMS.Data;
using FamileLMS.Models.Interfaces;
using FamileLMS.Models.Views;
using FamileLMS.UI.Models.Teacher;
using Microsoft.AspNet.Identity;

namespace FamileLMS.UI.Controllers
{
    public class TeacherController : Controller
    {

        private TeacherRepository _teacherRepository = new TeacherRepository();

        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            var model = _teacherRepository.GetTeacherDashboardItems(User.Identity.GetUserId());
            return View(model);
        }

        public ActionResult AddClass()
        {
            return View(new AddClass());
        }

        [HttpPost]
        public ActionResult AddClass(AddClass classInfo)
        {
            if (ModelState.IsValid)
            {
                var dto = classInfo.CreateClassFromUIModel();
                dto.UserID = User.Identity.GetUserId();
                _teacherRepository.AddClass(dto);
                return RedirectToAction("Index");
            }

            return View(classInfo);
        }

        public ActionResult EditClass(int id)//this needs to match route {id} exactly!
        {
            var model = new InfoAnalytics();
            var analyticData = _teacherRepository.GetAnalytics(id);//created a composite model for analytics and  the edit/class detail view
            model.GradeCounts = analyticData.StudentGradeAggregate;
            model.StudentCount = analyticData.StudentCount;

            var classInfo = _teacherRepository.GetClassInformationbyClassID(id);

            model.EditClassModel = new EditClass(classInfo); //model from "infoanalytics" UI model to bring over "edit class" constructor and pass class info object through  
            return View(model);
        }

        [HttpPost]
        public ActionResult EditClass(InfoAnalytics request)
        {
            if (ModelState.IsValid)
            {
                var dto = request.EditClassModel.CreateClassFromUIModel();
                dto.UserID = User.Identity.GetUserId();

                _teacherRepository.EditClass(dto);
                ViewBag.Message = "Course has been modified!";
            }
            return EditClass(request.EditClassModel.ClassID);
        }

        public ActionResult AddAssignment(int id)//route id!
        {

            var model = new AddAssignment();
            model.ClassID = id;//make sure you assign a class id to the model so you are adding the assignment to the right class
            model.ClassName = _teacherRepository.GetClassInformationbyClassID(id).ClassName;//if you need class information and it is not available in the model - request it here!
            model.DueDate = DateTime.Now.Date.AddDays(1);//set the default value for the due date (otherwise the non-nullable property defaults to Jan. 1, 0001)
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAssignment(AddAssignment assignment)
        {
            if (ModelState.IsValid)//ModelState.IsValid tells you if any model errors have been added to ModelState - ex passing non-number as int
            {
                var dto = assignment.CreateClassFromUIModel();
                dto.UserID = User.Identity.GetUserId();
                _teacherRepository.AddNewAssignmentbyClass(dto);
                return RedirectToAction("Gradebook",new{id=assignment.ClassID});
            }

            return View(assignment);
        }

        public ActionResult Gradebook()
        {
            return View();
        }

        public ActionResult ClassRoster()
        {
            return View();
        }

    }
}
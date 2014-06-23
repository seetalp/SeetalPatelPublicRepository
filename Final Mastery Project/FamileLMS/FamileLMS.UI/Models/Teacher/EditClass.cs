using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FamileLMS.Models.Views;

namespace FamileLMS.UI.Models.Teacher
{
    public class EditClass
    {
        [Required(ErrorMessage = "Please enter the class name")]
        public string ClassName { get; set; }

        [Required(ErrorMessage = "Please enter the class grade level")]
        public byte? GradeLevel { get; set; }

        [Required(ErrorMessage = "Please enter the class subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the start date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the end date")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Please enter the class description")]
        public string Description { get; set; }

        public bool IsArchived { get; set; }
        public int ClassID { get; set; }


        public EditClass()
        {
            
        }

        public EditClass(TeacherClassInformation classInfo)
        {
            this.ClassName = classInfo.ClassName;
            this.Description = classInfo.Description;
            this.Subject = classInfo.Subject;
            this.GradeLevel = classInfo.GradeLevel;
            this.StartDate = classInfo.StartDate;
            this.EndDate = classInfo.EndDate;
            this.IsArchived = classInfo.IsArchived;
            this.ClassID = classInfo.ClassID;
        }


        public TeacherClassInformation CreateClassFromUIModel()
        {
            return new TeacherClassInformation()
            {
                ClassName = this.ClassName,
                Description = this.Description,
                Subject = this.Subject,
                GradeLevel = this.GradeLevel.Value,
                StartDate = this.StartDate.Value,
                EndDate = this.EndDate.Value,
                ClassID = this.ClassID,
                IsArchived = this.IsArchived
            };
        }



    }
}
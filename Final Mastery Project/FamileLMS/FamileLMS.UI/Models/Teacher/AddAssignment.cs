using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FamileLMS.Models.Views;

namespace FamileLMS.UI.Models.Teacher
{
    public class AddAssignment
    {

        [Required(ErrorMessage = "Please enter the entry name")]
        public string EntryName { get; set; }

        [Required(ErrorMessage = "Please enter the entry type")]
        public string EntryType { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the total points possible")]
        public int PossiblePoints { get; set; }

        [Required(ErrorMessage = "Please enter a due date")]
        public DateTime DueDate { get; set; }

        
        public string ClassName { get; set; }
        public int ClassID { get; set; }
        public string UserID { get; set; }



        public Assignment CreateClassFromUIModel()
        {
            return new Assignment()
            {
                EntryName = this.EntryName,
                EntryType = this.EntryType,
                Description = this.Description,
                PossiblePoints = this.PossiblePoints,
                DueDate = this.DueDate,
                ClassID = this.ClassID,
                ClassName = this.ClassName,
            };
        }




    }
}
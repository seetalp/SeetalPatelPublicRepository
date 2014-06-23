using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views.GradebookModels
{
    public class GradebookRawData
    {
        public int ClassID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
        public string CourseLetterGrade { get; set; }
        public string EntryName { get; set; }
        public int EntryID { get; set; }
        public DateTime DueDate { get; set; }
        public double? AssignmentPercentGrade { get; set; }
        public string AssignmentLetterGrade { get; set; }
        public int? PointsScored { get; set; }
        public int PossiblePoints { get; set; }
    }
}

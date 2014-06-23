using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views.GradebookModels
{
    public class StudentGrade
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LetterGrade { get; set; }
        public int StudentID { get; set; }
        public List<StudentAssignmentEntry> Assignments { get; set; }
    }
}

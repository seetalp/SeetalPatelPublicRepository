using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views.GradebookModels
{
    public class GradeChangeRequest
    {
        public int ClassID { get; set; }
        public int EntryID { get; set; }
        public string LetterGrade { get; set; }
        public double PercentGrade { get; set; }
        public int? PointsScored { get; set; }
        public int StudentID { get; set; }
    }
}

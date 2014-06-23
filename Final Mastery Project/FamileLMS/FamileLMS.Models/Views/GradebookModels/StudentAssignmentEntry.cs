using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views.GradebookModels
{
    public class StudentAssignmentEntry
    {
        public int EntryID { get; set; }
        public double? PercentGrade { get; set; }
        public string LetterGrade { get; set; }
        public int? PointsScored { get; set; }
        public int PointsPossible { get; set; }
        public DateTime DueDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    public class StudentAndParentGrade
    {

        public int StudentID { get; set; }
        public int ClassID { get; set; }
        public string EntryName { get; set; }
        public string LetterGrade { get; set; }
        public double PercentGrade { get; set; }
        public DateTime DueDate { get; set; }
    }
}

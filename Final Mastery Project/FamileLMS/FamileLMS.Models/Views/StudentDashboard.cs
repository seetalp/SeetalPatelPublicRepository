using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    public class StudentDashboard
    {
        public int StudentID { get; set; }
        public string ClassName { get; set; }
        public string LetterGrade { get; set; }
        public int ClassID { get; set; }
        public string UserID { get; set; }
    }
}

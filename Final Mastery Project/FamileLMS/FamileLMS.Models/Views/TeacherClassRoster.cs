using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    public class TeacherClassRoster
    {
        public int StudentID { get; set; }
        public int ClassID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? GradeLevel { get; set; }
        public string UserName { get; set; }
    }
}

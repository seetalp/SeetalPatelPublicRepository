using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    public class TeacherDashboardItem
    {
        public string ClassName { get; set; }
        public int StudentCount { get; set; }
        public bool IsArchived { get; set; }
        public int ClassID { get; set; }
    }
}

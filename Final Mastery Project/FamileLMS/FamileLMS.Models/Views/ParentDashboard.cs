using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    public class ParentDashboard
    {
        public int ParentID { get; set; }
        public string UserID { get; set; }
        public int StudentID{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

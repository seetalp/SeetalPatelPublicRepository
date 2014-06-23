using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Requests
{
    public class RosterSearchRequest
    {
        public int StudentID{ get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GradeLevel { get; set; }
    }
}

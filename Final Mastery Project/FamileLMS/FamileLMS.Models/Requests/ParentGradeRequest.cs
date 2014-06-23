using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Requests
{
    public class ParentGradeRequest
    {
        public string ChildID { get; set; }
        public int ClassID { get; set; }
    }
}

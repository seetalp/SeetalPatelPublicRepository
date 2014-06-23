using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Requests
{
    public class RosterDeleteRequest
    {
        public int ClassID { get; set; }
        public int StudentID { get; set; }
    }
}

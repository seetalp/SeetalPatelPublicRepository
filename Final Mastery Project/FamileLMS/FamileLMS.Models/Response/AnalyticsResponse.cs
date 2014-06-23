using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Response
{
   public class AnalyticsResponse
    {
        //public int ClassID { get; set; }
 
        public List <GradeTableCount> StudentGradeAggregate { get; set; } 
        public int StudentCount { get; set; }
    }
}

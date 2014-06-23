using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
   public class TeacherClassInformation
    {

       public string UserID { get; set; }
       public byte GradeLevel { get; set; }
       public int ClassID { get; set; }
       public string ClassName { get; set; }
       public string Subject { get; set; }
       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
       public string Description { get; set; }
       public bool IsArchived { get; set; }
    }

}

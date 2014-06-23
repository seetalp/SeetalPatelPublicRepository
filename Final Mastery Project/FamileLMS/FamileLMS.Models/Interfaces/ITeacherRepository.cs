using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Models.Views;

namespace FamileLMS.Models.Interfaces
{
    public interface ITeacherRepository
    {
        List<TeacherDashboardItem> GetTeacherDashboardItems(string userId);
        TeacherClassInformation GetClassInformationbyClassID(int classId);
        void AddClass(TeacherClassInformation classInfo);
        void EditClass(TeacherClassInformation classInfo);
        void AddNewAssignmentbyClass(Assignment assignment);
    }
}
//We will only have list classes, add/view/edit classes and add assignment in the teacher repository
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Models.Requests;
using FamileLMS.Models.Views;


namespace FamileLMS.Models.Interfaces
{
    public interface IRosterRepository
    {

        List<TeacherClassRoster> GetClassRoster(int classId);
        void DeleteStudentFromClass(RosterDeleteRequest request);
        List<TeacherClassRoster> Search(TeacherClassRoster request);
        void AddToRoster(RosterAddRequest request);

    }
}

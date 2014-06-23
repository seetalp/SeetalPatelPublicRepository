using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FamileLMS.Data;
using FamileLMS.Models.Requests;
using FamileLMS.Models.Views;

namespace FamileLMS.UI.Controllers
{
    public class RosterAPIController : ApiController
    {

        public List<TeacherClassRoster> Get([FromUri] TeacherClassRoster request)
        {
            var repo = new RosterRepository();
            var students = repo.Search(request);

            return students ;
        }

        public HttpStatusCode Post(RosterAddRequest request)
        {
            var repo = new RosterRepository();
            repo.AddToRoster(request);

            return HttpStatusCode.OK;
        }
    


    public List<TeacherClassRoster> Get(int id)//gets class id
    {
        var repo = new RosterRepository();
        var roster = repo.GetClassRoster(id);

        return roster;
    }


    public HttpStatusCode Delete(RosterDeleteRequest request)//need to get student id and class id
        {
            var repo = new RosterRepository();
            repo.DeleteStudentFromClass(request);

            return HttpStatusCode.OK;
        }

}

}

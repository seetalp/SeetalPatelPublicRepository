using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FamileLMS.Data;
using FamileLMS.Models.Views.GradebookModels;

namespace FamileLMS.UI.Controllers
{
    public class GradebookController : ApiController
    {
        private GradebookRepository repo = new GradebookRepository();

        public GradebookFullPage Get(int id)
        {
            var model = repo.GetAllGradebookEntries(id);
            
            return model;
        }

        public HttpStatusCode Put(GradeChangeRequest input)
        {
            return repo.UpdateGrade(input);
        }
    }
}

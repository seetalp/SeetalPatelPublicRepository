using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FamileLMS.Models.Response;
using FamileLMS.Models.Views;
using Microsoft.Ajax.Utilities;

namespace FamileLMS.UI.Models.Teacher
{
    public class InfoAnalytics
    {
        public EditClass EditClassModel { get; set; }
        
           public int ClassID { get; set; }
           public int StudentCount { get; set; }
        public List<GradeTableCount> GradeCounts { get; set; }

    }
}
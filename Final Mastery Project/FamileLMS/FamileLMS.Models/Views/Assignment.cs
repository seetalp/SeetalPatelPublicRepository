using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamileLMS.Models.Views
{
    //SP-
    public class Assignment
    {
        public int EntryID { get; set;}
        public int ClassID { get; set;}
        public string EntryName { get; set;}
        public string EntryType { get; set;}
        public string Description { get; set;}
        public int PossiblePoints { get; set;}
        public DateTime DueDate { get; set;}
        public string UserID { get; set; }

        public string ClassName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.DTOs
{
    public class DVD
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
        public int Year { get; set; }
        public int Runtime { get; set; }
        public string Director { get; set; }
        public string Star { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level1
{
   public class LeapYearResponse
    {

        public int StartYear { get; set; }
        public int EndYear { get; set; }
        

        public LeapYearResponse()//Instantiate the list inside the model
        {
            LeapYearlist = new List<int>();
        }

        public List<int> LeapYearlist { get; set; }
    }
}

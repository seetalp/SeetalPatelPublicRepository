using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level2
{
   public class ChangeReturnResponse
    {
        public decimal ItemCost { get; set; }
        public decimal UserCash { get; set; }
        public decimal Change { get; set; }
        public int Cents { get; set; }
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }
      



    }
}

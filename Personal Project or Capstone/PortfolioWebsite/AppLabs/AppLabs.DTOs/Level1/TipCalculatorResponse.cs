using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level1
{
   public class TipCalculatorResponse
    {
        public decimal MealTotal { get; set; }
        public decimal TipPercent { get; set; }
        public decimal TipAmount { get; set; }
        public decimal TotalAmount { get; set; }


    }
}

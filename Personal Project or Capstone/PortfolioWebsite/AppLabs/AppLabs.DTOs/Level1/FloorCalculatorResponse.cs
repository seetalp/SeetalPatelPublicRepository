using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level1
{
   public class FloorCalculatorResponse
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalCost { get; set; }

    }
}

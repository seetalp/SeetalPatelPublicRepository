using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMetrics.Models
{
    public class TipCaculator
    {
        public decimal MealTotal { get; set; }
        public decimal TipPercent { get; set; }
        public decimal? Tip { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
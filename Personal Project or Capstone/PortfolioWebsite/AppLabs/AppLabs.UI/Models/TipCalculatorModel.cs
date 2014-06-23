using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class TipCalculatorModel
    {

      

        [Required(ErrorMessage = "Enter the meal cost")]
        [DisplayName("Meal Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? MealTotal { get; set; }

        [Required(ErrorMessage = "Enter the tip percent")]
        [DisplayName("Tip Percent")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal? TipPercent { get; set; }
    }
}
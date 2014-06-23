using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class LeapYearCalculatorModel
    {
        [Required(ErrorMessage = "Enter the 4-digit start year")]
        [DisplayName("Start Year")]
        [Range (0,9999)]
        public int? StartYear { get; set; }


        [Required(ErrorMessage = "Enter the 4-digit end year")]
        [DisplayName("End Year")]
        [Range(0, 9999)]
        public int? EndYear { get; set; }

    }
}
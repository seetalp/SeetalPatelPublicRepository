using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class CommonDenominatorModel
    {

        [Required(ErrorMessage = "Please provide a non-zero number")]
        [DisplayName("Numerator")]
        public int UserNumerator1 { get; set; }

        [Required(ErrorMessage = "Please provide a non-zero number")]
        [DisplayName("Denominator")]
        public int UserDenominator1 { get; set; }

        [Required(ErrorMessage = "Please provide a non-zero number")]
        [DisplayName("Comparison Numerator")]
        public int UserNumerator2 { get; set; }

        [Required(ErrorMessage = "Please provide a non-zero number")]
        [DisplayName("Comparison Denominator")]
        public int UserDenominator2 { get; set; }

    }
}
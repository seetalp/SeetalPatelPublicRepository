using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class RomanNumeralModel
    {

        [Required(ErrorMessage = "Enter a number between 1-1000 ")]
        [DisplayName("Number")]
        [Range (1, 1000)]
        public int UserNumber { get; set; }


    }
}
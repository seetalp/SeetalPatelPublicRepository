using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class MorseCodeModel
    {

        [Required(ErrorMessage = "Provide a word to translate into Morse Code")]
        [DisplayName("Word")]
        public string UserInput { get; set; }


    }
}
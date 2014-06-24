using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class CipherModel
    {


        [Required(ErrorMessage = "Enter a word or sentence")]
        [DisplayName("Sentence")]
        public string UserInput { get; set; }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class PalidromeFinderModel
    {

        [Required(ErrorMessage = "Enter a word to reverse")]
        public string Word { get; set; }


    }
}
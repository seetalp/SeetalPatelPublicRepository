using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AppLabs.BLL.Level2;

namespace AppLabs.UI.Models
{
    public class FibonacciModel
    {

        [Required(ErrorMessage = "Provide a non-negative number")]
        [Range(0, 20)]
        [DisplayName("nth term")]
        public int givenNumber { get; set; }

    


    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class VowelCounterModel
    {


        [Required(ErrorMessage = "Enter a word")]
        [DisplayName("Word")]
        public string Word { get; set; }




    }
}
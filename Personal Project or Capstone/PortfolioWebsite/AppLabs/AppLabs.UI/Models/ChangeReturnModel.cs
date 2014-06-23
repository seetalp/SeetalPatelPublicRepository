using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class ChangeReturnModel
    {


        [Required(ErrorMessage = "Enter the item cost")]
        [DisplayName("Item Cost")]
        public decimal? ItemCost { get; set; }


        [Required(ErrorMessage = "Enter the cash used to pay")]
        [DisplayName("Cash Rendered")]
        public decimal? UserCash { get; set; }




    }
}
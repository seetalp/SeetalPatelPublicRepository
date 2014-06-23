using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLabs.UI.Models
{
    public class FloorCalculatorModel
    {

        [Required(ErrorMessage = "Enter the floor length")]
        [DisplayName("Floor Length")]
        public int? Length { get; set; }

        [Required(ErrorMessage = "Enter the floor width")]
        [DisplayName("Floor Width")]
        public int? Width { get; set; }

        [Required(ErrorMessage = "Enter the unit cost")]
        [DisplayName("Unit Cost")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? UnitCost { get; set; }
    }

}
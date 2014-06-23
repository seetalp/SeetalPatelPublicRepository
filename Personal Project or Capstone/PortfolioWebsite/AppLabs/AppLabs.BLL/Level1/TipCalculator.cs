using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs;
using AppLabs.DTOs.Level1;

namespace AppLabs.BLL.Level1
{
    public class TipCalculator
    {

        public TipCalculatorResponse CalculateTip(TipCalculatorRequest data)
        {
            var result = new TipCalculatorResponse();

            result.MealTotal = data.MealTotal;
            result.TipPercent = data.TipPercent;
            result.TipAmount = result.MealTotal * (result.TipPercent/100);
            result.TotalAmount = result.TipAmount + result.MealTotal;

            return result;
        }
    }
}

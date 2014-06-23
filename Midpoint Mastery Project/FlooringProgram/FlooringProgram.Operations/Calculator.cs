using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Operations
{
    public class Calculator
    {
        public static void CalculateValues(Order currentOrder, TaxRate taxes, Product product)
        {
            currentOrder.MaterialCost = currentOrder.Area * product.CostPerSquareFoot;
            currentOrder.LaborCost = currentOrder.Area * product.LaborCostPerSquareFoot;
            currentOrder.Tax = (currentOrder.LaborCost + currentOrder.MaterialCost) * taxes.TaxPercent;
            currentOrder.Total = currentOrder.LaborCost + currentOrder.MaterialCost + currentOrder.Tax;
            
        }
    }
}

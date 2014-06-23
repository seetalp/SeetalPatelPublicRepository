using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level1;

namespace AppLabs.BLL.Level1
{
    public class FloorCalculator
    {

        public FloorCalculatorResponse CalculateFloorCost(FloorCalculatorRequest request)
        {
            FloorCalculatorResponse response = new FloorCalculatorResponse();

            response.Length= request.Length;
            response.Width = request.Width;
            response.UnitCost = request.UnitCost;
            response.TotalCost = (response.Length * response.Width) * response.UnitCost;

            return response;

        }
    }
}

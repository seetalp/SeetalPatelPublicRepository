using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level2;

namespace AppLabs.BLL.Level2
{
    public class ChangeReturnCalculator
    {

        public ChangeReturnResponse CalculateChange(ChangeReturnRequest request)
        {
            var response = new ChangeReturnResponse();

            response.UserCash = (decimal) (request.UserCash);
            response.ItemCost = request.ItemCost;
            response.Change = (decimal) ((request.UserCash - request.ItemCost)*100);

            response.Cents = (int) response.Change;
            response.Quarters = response.Cents/25;
            response.Cents -= response.Quarters*25;
            response.Dimes = response.Cents/10;
            response.Cents -= response.Dimes * 10;
            response.Nickels = response.Cents / 5;
            response.Cents -= response.Nickels * 5;
            response.Pennies = response.Cents / 1;
            response.Cents -= response.Pennies* 1;

            return response;
        }

     
    }
}






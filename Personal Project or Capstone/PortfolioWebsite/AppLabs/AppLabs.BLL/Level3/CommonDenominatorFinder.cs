using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level3;

namespace AppLabs.BLL.Level3
{
   public  class CommonDenominatorFinder
    {
       public CommonDenominatorResponse FindDenominator(CommonDenominatorRequest request)
       {

           var response = new CommonDenominatorResponse();
           response.UserDenominator1 = request.UserDenominator1;
           response.UserDenominator2 = request.UserDenominator2;
           response.Min = Math.Min(response.UserDenominator1, response.UserDenominator2);
           response.GCD = 1;
           response.Holder = 1;

           

           while (response.Holder <= response.Min)
           {
               if (response.UserDenominator1%response.Holder == 0 && response.UserDenominator2%response.Holder == 0)
               {
                   response.GCD = response.Holder;
               }
               response.Holder++;
           }
           return response;
       }
       
    }
}



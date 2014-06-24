using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level4;

namespace AppLabs.BLL.Level4
{
   public class RomanNumeralConverter
    {


       public RomanNumeralResponse ConvertNumber(RomanNumeralRequest request)
       {
           var response = new RomanNumeralResponse();
           response.UserNumber = request.UserNumber;
           response.RomanNumeral = "";
           var temp = new StringBuilder();

           foreach (var item in response.NumberToNumeralDictionary)
           {
               while (response.UserNumber >= item.Key)
               {
                   temp.Append(item.Value);
                   response.UserNumber -= item.Key;
               }
           }
           response.RomanNumeral = temp.ToString();
           return response;

       }
    }
}



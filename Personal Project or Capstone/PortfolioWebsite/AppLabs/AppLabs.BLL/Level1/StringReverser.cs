using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level1;

namespace AppLabs.BLL.Level1
{
  public  class StringReverser
    {

        public StringReverseResponse FindReverseString(StringReverseRequest request)
        {
            StringReverseResponse response = new StringReverseResponse();

            response.String = request.String;
            response.ReversedString = "";

            for (int i = response.String.Length-1; i >= 0; i--)
            {
                response.ReversedString += response.String[i]; 

            }
            return response;
        }
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level4;

namespace AppLabs.BLL.Level4
{
    public class MorseCodeConverter
    {
        public MorseCodeResponse ConvertToMorse(MorseCodeRequest request)
        {
            var response = new MorseCodeResponse();
            response.UserInput = request.UserInput;
            response.ModifiedInput = request.UserInput.ToUpper();
            var temp = new StringBuilder();

            for (int i = 0; i < response.ModifiedInput.Length; i++)
            {
                if (i > 0)
                {
                    response.Output = temp.Append('/').ToString();
                }
                    

                char c = response.ModifiedInput[i];
                if (response.MorseCodes.ContainsKey(c))
                {
                    temp.Append(response.MorseCodes[c]);//SP checkpoint: need to point to only one value not the whole dictionary!
                }
                response.Output = temp.ToString();
            }

            return response;




        }
    }
}


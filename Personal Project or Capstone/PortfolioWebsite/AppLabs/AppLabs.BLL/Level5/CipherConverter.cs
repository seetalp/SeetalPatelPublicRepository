using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level5;

namespace AppLabs.BLL.Level5
{
    public class CipherConverter
    {
        public CipherResponse EncryptWord(CipherRequest request)
        {
            var response = new CipherResponse();
            response.UserInput = request.UserInput;
            response.ModifiedInput = response.UserInput.ToUpper();
            var temp = new StringBuilder();

            for (int i = 0; i < response.ModifiedInput.Length; i++)
            {
                char c = response.ModifiedInput[i];
                if (response.Caesar.ContainsKey(c))
                {
                    temp.Append(response.Caesar[c]);
                }

                    
                    response.Output = temp.ToString();
            }

            return response;
        }
        


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level2;

namespace AppLabs.BLL.Level2
{
    public class VowelCounterCalculator
    {

        public VowelCounterResponse FindVowels(VowelCounterRequest request)
        {
            var response = new VowelCounterResponse();

            for (int i = 0; i < request.Word.Length; i++)//behaves like a foreach loop
            {
                if (request.Word[i] == 'a' || request.Word[i] == 'i' || request.Word[i] == 'o' || request.Word[i] == 'u' || request.Word[i] == 'e')

                    request.Count++;
            }

            response.VowelCount = request.Count;
            return response;

        }


        }

        
}

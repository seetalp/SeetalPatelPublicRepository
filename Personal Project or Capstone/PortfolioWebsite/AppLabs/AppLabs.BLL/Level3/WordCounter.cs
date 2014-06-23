using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level3;

namespace AppLabs.BLL.Level3
{
    public class WordCounter
    {

        public WordCounterResponse CountWords(WordCounterRequest request)
        {

            var response = new WordCounterResponse();

            response.UserInput = request.UserInput;

            string[] split = response.UserInput.Split(' ');

            foreach (var s in split)
            {
                if (s.Trim() != "")
                    response.Counter++;

            }

            return response;

        }


    }
}

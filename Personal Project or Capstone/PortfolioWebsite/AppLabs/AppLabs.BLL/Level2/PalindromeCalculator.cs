using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level2;

namespace AppLabs.BLL.Level2
{
   

public class PalindromeCalculator
    {


        public PalindromFinderResponse FindPalindrome(PalindromFinderRequest request)
        {
            var response = new PalindromFinderResponse();

            response.Word = request.Word;
            response.ModifiedWord = "";


            for (int i = response.Word.Length-1; i >= 0; i--)
            {
                response.ModifiedWord += response.Word[i];
            }

            if (response.ModifiedWord != request.Word)
                {
                    response.IsPalindrome = false;
                }
                else
                {
                    response.IsPalindrome = true;
                }

                return response;
        }
       
            


        }

       

    }


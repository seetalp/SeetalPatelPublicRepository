using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.DTOs.Level5
{
   public class CipherResponse
    {


       public string UserInput { get; set; }
       public string ModifiedInput { get; set; }
       public string Output { get; set; }
       public Dictionary<char, String> Caesar { get; set; }

       public CipherResponse()

       {

           Caesar = new Dictionary<char, String>
           {
               {'A', "X"},
               {'B', "Y"},
               {'C', "Z"},
               {'D', "A"},
               {'E', "B"},
               {'F', "C"},
               {'G', "D"},
               {'H', "E"},
               {'I', "F"},
               {'J', "G"},
               {'K', "H"},
               {'L', "I"},
               {'M', "J"},
               {'N', "K"},
               {'O', "L"},
               {'P', "M"},
               {'Q', "N"},
               {'R', "O"},
               {'S', "P"},
               {'T', "Q"},
               {'U', "R"},
               {'V', "S"},
               {'W', "T"},
               {'X', "U"},
               {'Y', "V"},
               {'Z', "W"},
               {' ', " "},
           };

       }

    }
}

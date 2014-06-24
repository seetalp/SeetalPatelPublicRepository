using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.BLL.Level4;
using AppLabs.DTOs.Level4;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
   public class MorseCodeTest
   {
        [Test]
       public void MorseCodeTester()
       {
           var response = new MorseCodeConverter();
           var request = new MorseCodeRequest(){UserInput = "Sam"};
           var result = response.ConvertToMorse(request);
        
           //".../.-/--"

           Assert.AreEqual(result.Output, ".../.-/--");
       } 

    }
}

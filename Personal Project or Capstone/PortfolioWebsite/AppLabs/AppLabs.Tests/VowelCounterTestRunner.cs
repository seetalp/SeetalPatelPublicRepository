using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.BLL.Level2;
using AppLabs.DTOs.Level2;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
    class VowelCounterTestRunner
    {
            [Test]
            public void FindVowelTest()
            {

                var request = new VowelCounterRequest();
                request.Word = "yellow";

                VowelCounterCalculator response = new VowelCounterCalculator();
                var output = response.FindVowels(request);

                Assert.AreEqual(output.VowelCount, 2);
                
            }

    }
}

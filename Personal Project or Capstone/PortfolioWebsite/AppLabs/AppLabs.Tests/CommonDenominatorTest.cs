using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.BLL.Level3;
using AppLabs.DTOs.Level3;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
    public class CommonDenominatorTest
    {


        [Test]
        public void FindGreatestDenominatorTest()
        {
            var finder = new CommonDenominatorFinder();
            var request = new CommonDenominatorRequest(){UserDenominator1 =5,UserDenominator2 = 10,UserNumerator1 = 1,UserNumerator2 = 1};
            var result = finder.FindDenominator(request);

        
            Assert.AreEqual(result.GCD, 5);
        }


    }
}

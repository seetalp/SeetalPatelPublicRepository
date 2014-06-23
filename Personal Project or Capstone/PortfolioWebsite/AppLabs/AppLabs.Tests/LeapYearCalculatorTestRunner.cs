using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level1;
using NUnit.Framework;
using AppLabs.BLL.Level1;

namespace AppLabs.Tests
{
    [TestFixture]
   class LeapYearCalculatorTestRunner
    {
        [Test]
        public void CalculateLeapYearTest()
        {
            var request = new LeapYearRequest();

            request.StartYear = 1991;
            request.EndYear = 1998;

            LeapYearCalculator response = new LeapYearCalculator();
            var output = response.FindLeapYear(request);
            var actual = output.LeapYearlist ;
            int[] expected = { 1992, 1996 };

            Assert.AreEqual(actual, expected);
        }

    }
}

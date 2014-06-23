using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.BLL.Level1;
using AppLabs.DTOs.Level1;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
    class TipCalculatorTestRunner
    {
        [Test]
        public void CalculateTipTest()
        {
            var calculator = new TipCalculator();

            var request = new TipCalculatorRequest { MealTotal = 100, TipPercent = 10M };

            var result = calculator.CalculateTip(request);

            Assert.AreEqual(result.TipAmount, 10M);
            Assert.AreEqual(result.TotalAmount, 110M);
        }


    }
}

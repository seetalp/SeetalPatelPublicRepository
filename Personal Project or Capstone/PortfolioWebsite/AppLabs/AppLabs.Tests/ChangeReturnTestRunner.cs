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
    public class ChangeReturnTestRunner
    {
        [Test]
        public void CalculateReturnChangeTest()
        {
            var calculator = new ChangeReturnCalculator();
            var request = new ChangeReturnRequest(){UserCash = 2.00M, ItemCost = 1.32M};
            var result = calculator.CalculateChange(request);

            Assert.AreEqual(result.Quarters, 2 );
            Assert.AreEqual(result.Dimes, 1 );
            Assert.AreEqual(result.Nickels, 1 );
            Assert.AreEqual(result.Pennies, 3 );
        }
    }
}


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
    class FloorCalculatorTestRunner
    {

        [Test]
        public void CalculateFloorTest()
        {
            var calculator = new FloorCalculator();

            var request = new FloorCalculatorRequest{ UnitCost = 1M, Length = 10, Width = 10};

            var result = calculator.CalculateFloorCost(request);

            Assert.AreEqual(result.TotalCost, 100M);
           
            
        }


    }
}

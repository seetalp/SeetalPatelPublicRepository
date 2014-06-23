using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.DTOs.Level2;
using AppLabs.BLL.Level2;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
    class FibonacciTestRunner
    {

        [Test]
        public void CalculateFibonacciTest()
        {
            var request = new FibonacciListerRequest();
            request.givenNumber = 5;

            var response = new FibonacciCalculator();
            var output = response.FibonacciLister(request);
            var actual = output.fibonacciList;
            int[] expected = {  1, 1, 2, 3, 5 };

            Assert.AreEqual(actual, expected);
        }

    }


}

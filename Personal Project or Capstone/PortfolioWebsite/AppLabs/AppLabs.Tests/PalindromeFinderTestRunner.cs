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
    class PalindromeFinderTestRunner
    {

        [Test]
        public void PalindromeFinderTest()
        {
            var finder = new PalindromeCalculator();

            var request = new PalindromFinderRequest() {Word = "noon"};

            var result = finder.FindPalindrome(request);

            Assert.AreEqual(result.Word, "noon");
            Assert.AreEqual(result.ModifiedWord, "noon");
            Assert.AreEqual(result.IsPalindrome, true);


        }



    }
}

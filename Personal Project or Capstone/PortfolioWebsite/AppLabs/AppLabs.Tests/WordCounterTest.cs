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
    public class WordCounterTest
    {
        [Test]
        public void CounterTest()
        {
            var request = new WordCounterRequest();
            request.UserInput = "This is a test.";

            var result = new WordCounter();
            var output = result.CountWords(request);

            Assert.AreEqual(output.Counter, 4);
        }


    }
}

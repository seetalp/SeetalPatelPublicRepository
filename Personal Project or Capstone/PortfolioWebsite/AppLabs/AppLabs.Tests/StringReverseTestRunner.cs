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
    class StringReverseTestRunner
    {

        [Test]
        public void ReverseStringTest()
        {
            var request = new StringReverseRequest();
            request.String = "backwards";

            StringReverser response = new StringReverser();
            var output = response.FindReverseString(request);

            Assert.AreEqual(output.ReversedString, "sdrawkcab");
            
        }

    }
}

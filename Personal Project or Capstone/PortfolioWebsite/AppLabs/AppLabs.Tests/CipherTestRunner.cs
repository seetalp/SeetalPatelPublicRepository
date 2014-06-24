using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLabs.BLL.Level5;
using AppLabs.DTOs.Level5;
using NUnit.Framework;

namespace AppLabs.Tests
{
    [TestFixture]
    public class CipherTestRunner
    {
        [Test]
        public void CipherTest()
        {

            var cipherConverter = new CipherConverter();
            var request = new CipherRequest() { UserInput = "Test"};
            var result = cipherConverter.EncryptWord(request);

            Assert.AreEqual(result.Output,"QBPQ" );


        }

    }
}

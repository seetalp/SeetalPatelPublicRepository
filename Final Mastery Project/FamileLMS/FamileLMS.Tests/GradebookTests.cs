using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamileLMS.Data;
using NUnit.Framework;

namespace FamileLMS.Tests
{
    [TestFixture]
    public class GradebookTests
    {
        [Test]
        public void GetAll()
        {
            var repo = new GradebookRepository();
            var expected = repo.GetAllGradebookEntries(1);

            Assert.AreNotEqual(0, expected.AssignmentNames.Count);
        }
    }
}

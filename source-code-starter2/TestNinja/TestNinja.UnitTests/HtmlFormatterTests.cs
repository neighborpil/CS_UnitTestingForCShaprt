using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter formatter;

        [SetUp]
        public void SetUp()
        {
            formatter = new HtmlFormatter();
        }

        [Test]
        [TestCase("abc")]
        [TestCase("Abc")]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement(string message)
        {
            var result = formatter.FormatAsBold(message);

            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.Contain(message).IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void FormatAsBold_CalledWithEmptyAndWhiteSpaceString_ReturnArgumentException(string message)
        {
            Assert.That(() => formatter.FormatAsBold(message), Throws.ArgumentException);
        }
    }
}

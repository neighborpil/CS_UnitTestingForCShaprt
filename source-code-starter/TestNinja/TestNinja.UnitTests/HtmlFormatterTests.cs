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
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");
            /*
            // Specific
            Assert.That(result, Is.EqualTo("<string>abc</string>")); // ", /, ~등 여러가지 기호가 올 수도 있는데
                                                                     // 너무 구체적인 테스트라 나중에 crash 할 수 있다
            // More General
            Assert.That(result, Does.StartWith("<strong>"));

            // More General2
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("<strong>")); // <strong>만 있는거는 잡을 수 있지만, empty한 string은 잡을 수 없다
            */

            // Proper
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }

        [Test]
        public void FormatAsBold_TestCaseSenstiveString_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("abc");
            
            /* case-senstive: 대소문자 구분 */

            //Assert.That(result, Does.Contain("Abc")); // 기본적으로 case-senstive이다
            Assert.That(result, Does.Contain("Abc").IgnoreCase); // string의 대소문자 구분 무시한다
        }
    }
}

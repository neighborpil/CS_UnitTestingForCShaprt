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
    public class ErrorLoggerTests
    {
        private ErrorLogger logger;

        [SetUp]
        public void SetUp()
        {
            logger = new ErrorLogger();
        }

        [Test]
        [TestCase("a")]
        [TestCase("A")]
        public void Log_WhenCalled_SetTheLastErrorProperty(string messages)
        {
            logger.Log(messages);
            Assert.That(logger.LastError, Is.EqualTo(messages));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Log_InvalidError_ThrowArugmentNullException(string message)
        {
            Assert.That(() => logger.Log(message), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("a")]
        public void Log_InvokeEvent_RaiseErrorLoggedEvnet(string message)
        {
            var guid = Guid.Empty;
            logger.ErrorLogged += (sender, args) => guid = args;
            logger.Log(message);
            Assert.That(guid, Is.Not.EqualTo(Guid.Empty));

        }
    }
}

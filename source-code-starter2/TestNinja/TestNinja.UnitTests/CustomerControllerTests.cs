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
    public class CustomerControllerTests
    {
        private CustomerController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFoundInstance()
        {
            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());
            Assert.That(result, Is.InstanceOf<NotFound>()); // include derived classes
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnNotFoundInstance()
        {
            var result = controller.GetCustomer(1);

            Assert.That(result, Is.TypeOf<Ok>());
            Assert.That(result, Is.InstanceOf<Ok>()); // include derived classes
        }
    }
}

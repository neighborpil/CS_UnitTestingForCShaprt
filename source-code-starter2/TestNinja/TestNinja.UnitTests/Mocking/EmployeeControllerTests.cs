using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> storage;
        private EmployeeController controller;

        [SetUp]
        public void SetUp()
        {
            storage = new Mock<IEmployeeStorage>();
            controller = new EmployeeController(storage.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_ReturnActionResult()
        {
            storage.Setup(s => s.DeleteEmployee(It.IsAny<int>()));

            var result = controller.DeleteEmployee(1);

            Assert.That(result, Is.InstanceOf<ActionResult>());
        }

        [Test]
        public void DeleteEmployee_WhenCalled_VerifyAvocation()
        {
            storage.Setup(s => s.DeleteEmployee(It.IsAny<int>()));

            controller.DeleteEmployee(1);

            storage.Verify(s => s.DeleteEmployee(It.IsAny<int>()));
        }
    }
}

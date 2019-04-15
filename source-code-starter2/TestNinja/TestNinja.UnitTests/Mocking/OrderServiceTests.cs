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
    public class OrderServiceTests
    {
        [Test]
        public void PlaceHolder_WhenCalled_StoreTheOrder()
        {
            var fakeStorage = new Mock<IStorage>();
            var service = new OrderService(fakeStorage.Object);

            var order = new Order();
            service.PlaceOrder(order);

            fakeStorage.Verify(s => s.Store(order));
        }
    }
}

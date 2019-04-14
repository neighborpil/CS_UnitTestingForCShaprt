
using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ReceiveNullObject_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase(new []{"a", "b", "c"}, 3)]
        [TestCase(new string[]{}, 0)]
        [TestCase(new[] { "a" }, 1)]
        public void Push_ReceiveString_IncreaseListCount(string[] values, int count)
        {
            var stack = new Stack<string>();
            foreach (var value in values)
                stack.Push(value);
            Assert.That(stack.Count, Is.EqualTo(count));
        }

        [Test]
        public void Pop_PopUpItems_TryToPopUpOnTheEmptyList()
        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Pop();
            stack.Pop();
            stack.Pop();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_PopUpItems_ReturnItemsInTheList()
        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            var result = stack.Pop();
            Assert.That(result, Is.EqualTo("B"));
            result = stack.Pop();
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        public void Peek_TryToPeekEmptyList_ThrowsInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_PeekItem_ReturnItemOnTheTopAndNeverChangeCount()
        {
            var stack = new Stack<string>();
            var lastItem = "B";

            stack.Push("A");
            stack.Push(lastItem);

            var countBeforePeek = stack.Count;

            var result = stack.Peek();

            Assert.That(countBeforePeek, Is.EqualTo(stack.Count));
            Assert.That(result, Is.EqualTo(lastItem));
        }
    }
}

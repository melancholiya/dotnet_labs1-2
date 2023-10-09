using AutoFixture;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected DoubleEndedQueue<T> CreateDeque<T>()
        {
            return new DoubleEndedQueue<T>();
        }
        protected void AssertDequeIsEmpty<T>(DoubleEndedQueue<T>deque)
        {
            deque.Count.Should().Be(0);
            deque.Head.Should().BeNull();
            deque.Tail.Should().BeNull();
        }

        //protected IFixture Fixture { get; } = new Fixture();

    }
}
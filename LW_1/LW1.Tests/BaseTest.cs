using AutoFixture;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class BaseTest<T>
    {
        protected DoubleEndedQueue<T> Deque;
        [SetUp]
        public void SetUp()
        {
            Deque = new DoubleEndedQueue<T>();
           
        }
        

    }
}
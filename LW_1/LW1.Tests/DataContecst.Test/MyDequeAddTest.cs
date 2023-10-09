using System;
using System.Reflection;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class MyDequeAddTest:BaseTest
    {
        //[TestCase(1,2,2)]
        [TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.TestCases))]
        public void AddFirst_AddsItemOfDifferentTypes<T>(T item1, T item2, T expectedHead)
        {
            //Arrange
            var deque = CreateDeque<T>();
            //Act
            deque.AddFirst(item1);
            deque.AddFirst(item2);
            //Assert
            deque.Head.Value.Should().BeEquivalentTo(expectedHead);
            deque.Tail.Value.Should().BeEquivalentTo(item1);
            deque.Count.Should().Be(2);
        }
        
        
    }
}
using System;
using System.Reflection;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class MyDequeAddFirstTest:BaseTest<object>
    {
        [Test]
        [TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.TestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenAddFirst_ThenItemIsAddedToTheBeginning<T>(T initialValue, 
            T itemToAdd, T expectedResult)
        {
            //Arrange (Given)
            Deque.AddFirst(initialValue);
            //Act (When)
            Deque.AddFirst(itemToAdd);
            //Assert (Then)
            Deque.Head.Value.Should().BeEquivalentTo(itemToAdd);
            Deque.Tail.Value.Should().BeEquivalentTo(initialValue);
            Deque.Count.Should().Be(2);
        }
        [Test]
        [TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.TestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenAddFirst_ThenItemIsAddedToTheBeginning<T>(object initialValue, 
            T itemToAdd)
        {
            //Arrange (Given)
            //realized in SetUp
            //Act
            Deque.AddFirst(itemToAdd);
            //Assert
            Deque.Head.Value.Should().BeEquivalentTo(itemToAdd);
            Deque.Tail.Value.Should().BeEquivalentTo(itemToAdd);
            Deque.Count.Should().Be(1);
        }

        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.TestCasesWithValues))]
        public void GivenEventSubscription_WhenAddFirst_ThenAddedToBeginningEventIsRaised<T>(T initialValue,
            T itemToAdd, T expectedResult)
        {
            //Arrange (Given)
            var eventRaised = false;
            Deque.AddedToBeginning += (sender, item) => eventRaised = true;
            //Act (When)
            Deque.AddFirst(itemToAdd);
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
        
        
        
    }
}
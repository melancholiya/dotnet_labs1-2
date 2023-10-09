using FluentAssertions;
using NUnit.Framework;

namespace LW1.Tests
{
    public class MyDequeRemoveFirstTest:BaseTest<object>
    {
        [Test]
        [TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.TestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenRemoveFirst_ThenItemIsRemovedFromTheBeginning<T>(T initialValue, 
            T itemToAdd, T expectedResult)
        {
            //Arrange (Given)
            Deque.AddFirst(initialValue);
            Deque.AddFirst(itemToAdd);
            //Act (When)
            Deque.RemoveFirst();
            //Assert (Then)
            Deque.Head.Value.Should().BeEquivalentTo(initialValue);
            Deque.Tail.Value.Should().BeEquivalentTo(initialValue);
            Deque.Count.Should().Be(1);
        }
        [Test]
        [TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.TestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenRemoveFirst_ThenInvalidOperationExceptionIsThrown<T>(object initialValue, 
            T itemToAdd)
        {
            //Arrange (Given)
            //realized in SetUp
            //Act
            //Assert
            Assert.That(() => Deque.RemoveFirst(), Throws.InvalidOperationException);
        }
        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.TestCasesWithValues))]
        public void GivenEventSubscription_WhenRemoveFirst_ThenRemovedFromBeginningEventIsRaised<T>(T initialValue,
            T itemToAdd, T expectedResult)
        {
            //Arrange (Given)
            var eventRaised = false;
            Deque.ElementRemoved += (sender, item) => eventRaised = true;
            Deque.AddFirst(itemToAdd);
            //Act (When)
            Deque.RemoveFirst();
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.TestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenRemoveFirst_ThenCollectionIsEmpty<T>(T initialValue,
            T itemToAdd, T expectedResult)
        {
            //Arrange (Given)
            Deque.AddFirst(itemToAdd);
            //Act (When)
            Deque.RemoveFirst();
            //Assert (Then)
            Deque.Count.Should().Be(0);
            Deque.Head.Should().BeNull();
            Deque.Tail.Should().BeNull();
           
        }
        
    }
}
using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace LW1.Tests.AddTests
{
    [TestFixture]
    public class MyDequeAddFirstTest
    {
        //if count>0, then add item to the beginning
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenAddFirst_ThenItemIsAddedToTheBeginning(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            var expectedItem = testCaseData.ExpectedItem;
            //Act (When)
            deque.AddFirst(expectedItem);
            //Assert (Then)
            deque.Head.Value.Should().Be(expectedItem);
            deque.Tail.Should().NotBeNull();
        }
        //if count == 0, then add item to the beginning
        [Test,TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenAddFirst_ThenItemIsAddedToTheBeginning(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            var expectedItem = testCaseData.ExpectedItem;
            //Act (When)
            deque.AddFirst(expectedItem);
            //Assert (Then)
            deque.Head.Value.Should().Be(expectedItem);
            deque.Tail.Value.Should().Be(expectedItem);
        }
        
        //event is raised when item is added to the beginning
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenEventSubscription_WhenAddFirst_ThenAddedToBeginningEventIsRaised(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var eventRaised = false;
            var deque = testCaseData.Deque;
            var expectedItem = testCaseData.ExpectedItem;
            
            var addedToBeginningHandlerMock = new Mock<EventHandler<int>>();
            addedToBeginningHandlerMock.Setup(x => x.Invoke(deque, expectedItem));
            deque.AddedToBeginning += (sender, item) => eventRaised = true;
            //Act (When)
            deque.AddFirst(expectedItem);
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
    }
}
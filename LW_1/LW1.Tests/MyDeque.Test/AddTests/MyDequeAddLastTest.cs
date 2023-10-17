using System;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class MyDequeAddLastTest
    {
        //if count > 0, then tail.Value should be the last item in the deque
        [Test,TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenAddLast_ThenItemIsAddedToTheEnd(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            var itemToAdd = testCaseData.ExpectedItem;
            //Act (When)
            deque.AddLast(itemToAdd);
            //Assert (Then)
            deque.Head.Should().NotBeNull();
            deque.Tail.Value.Should().Be(itemToAdd);
        }
        //if count == 0
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenAddLast_ThenItemIsAddedToTheEnd(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            var itemToAdd = testCaseData.ExpectedItem;
            //Act (When)
            deque.AddLast(itemToAdd);
            //Assert (Then)
            deque.Head.Value.Should().Be(itemToAdd);
            deque.Tail.Value.Should().Be(itemToAdd);
            deque.Count.Should().Be(1);
        }
        //if item == null, then throw exception
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void GivenNullItem_WhenAddLast_ThenArgumentNullExceptionIsThrown(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = new DoubleEndedQueue<string>();
            //Act (When)
            var action = () => deque.AddLast(null);
            //Assert (Then)
            action.Should().Throw<ArgumentNullException>();
        }
        [Test,TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenEventSubscription_WhenAddLast_ThenAddedToEndingEventIsRaised(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var eventRaised = false;
            var deque = testCaseData.Deque;
            var itemToAdd = testCaseData.ExpectedItem;
            deque.AddedToEnd += (sender, item) => eventRaised = true;
            //Act (When)
            deque.AddLast(itemToAdd);
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
    }
}
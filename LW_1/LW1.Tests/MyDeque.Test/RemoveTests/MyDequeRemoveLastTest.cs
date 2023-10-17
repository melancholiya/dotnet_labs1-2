using System;
using FluentAssertions;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

namespace LW1.Tests.RemoveTests
{
    [TestFixture]
    public class MyDequeRemoveLastTest
    {
        //if count == 0
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenRemoveLast_ThenInvalidOperationException(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            //Act (When)
            var action = () => deque.RemoveLast();
            //Assert (Then)
            action.Should().Throw<InvalidOperationException>();
           
        }
        //if count == 1
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithOneElement))]
        public void GivenNotEmptyDeque_WhenRemoveLast_ThenCollectionIsEmpty(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            // Act (When)
            deque.RemoveLast();
            // Assert (Then)
            deque.Count.Should().Be(0);
            deque.Head.Should().BeNull();
            deque.Tail.Should().BeNull();
        }
        //event is raised
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenEventSubscription_WhenRemoveLast_ThenRemovedFromEndingEventIsRaised(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var eventRaised = false;
            var deque = testCaseData.Deque;
            deque.ElementRemoved += (sender, item) => eventRaised = true;
            //Act (When)
            deque.RemoveLast();
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
        //if count>1
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
        public void GivenNonEmptyDeque_WhenRemoveLast_ThenItemIsRemovedFromCollection(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            //Act (When)
            deque.RemoveLast();
            //Assert (Then)
            deque.Tail.Next.Should().BeNull();
        }
       
    }
}
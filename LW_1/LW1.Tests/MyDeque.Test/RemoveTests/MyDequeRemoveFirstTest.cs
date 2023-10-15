using System;
using FluentAssertions;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class MyDequeRemoveFirstTest
    {
        //if count > 1, then remove first item from the beginning
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenNonEmptyDeque_WhenRemoveFirst_ThenItemIsRemovedFromTheBeginning(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var doubleEndedQueue = testCaseData.Deque;
            //Act (When)
            var actualItem = doubleEndedQueue.RemoveFirst();
            //Assert (Then)
            actualItem.Should().Be(testCaseData.ExpectedItem);
        }
        //if count == 1, then remove first item from the beginning
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithOneElement))]
        public void GivenDequeWithOneElement_WhenRemoveFirst_ThenItemIsRemovedFromTheBeginning(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var doubleEndedQueue = testCaseData.Deque;
            //Act (When)
            var actualItem = doubleEndedQueue.RemoveFirst();
            //Assert (Then)
            actualItem.Should().Be(testCaseData.ExpectedItem);
            doubleEndedQueue.Count.Should().Be(0);
            doubleEndedQueue.Head.Should().BeNull();
            doubleEndedQueue.Tail.Should().BeNull();
        }
        //if count == 0, then throw InvalidOperationException
        [Test, TestCaseSource(typeof(ObjectTestData) ,nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void GivenEmptyDeque_WhenRemoveFirst_ThenInvalidOperationExceptionIsThrown(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var deque = testCaseData.Deque;
            //Act & Assert (When & Then)
            Assert.Throws<InvalidOperationException>(() => deque.RemoveFirst());
        }
        //event is raised
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void GivenEventSubscription_WhenRemoveFirst_ThenRemovedFromBeginningEventIsRaised(TestCaseData testCaseData)
        {
            //Arrange (Given)
            var eventRaised = false;
            var deque = testCaseData.Deque;
            deque.ElementRemoved += (sender, item) => eventRaised = true;
            //Act (When)
            deque.RemoveFirst();
            //Assert (Then)
            eventRaised.Should().BeTrue();

        }
           
        }
    }

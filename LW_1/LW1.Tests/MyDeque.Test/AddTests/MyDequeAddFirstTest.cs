using FluentAssertions;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

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
            deque.AddedToBeginning += (sender, item) => eventRaised = true;
            //Act (When)
            deque.AddFirst(expectedItem);
            //Assert (Then)
            eventRaised.Should().BeTrue();
        }
    }
}
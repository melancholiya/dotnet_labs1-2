using FluentAssertions;
using NUnit.Framework;

namespace LW1.Tests;
[TestFixture]
public class MyDequeClearTest
{
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
    public void GivenNonEmptyDeque_WhenClear_ThenDequeIsEmpty(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var deque = testCaseData.Deque;
        //Act (When)
        deque.Clear();
        //Assert (Then)
        deque.Count.Should().Be(0);
        deque.Head.Should().BeNull();
        deque.Tail.Should().BeNull();
    }
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
    public void GivenEventSubscription_WhenClear_ThenClearedEventIsRaised(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var eventRaised = false;
        var deque = testCaseData.Deque;
        deque.CollectionCleared += (sender, item) => eventRaised = true;
        //Act (When)
        deque.Clear();
        //Assert (Then)
        eventRaised.Should().BeTrue();
    }
}
using FluentAssertions;
using NUnit.Framework;

namespace LW1.Tests;
[TestFixture]
public class MyDequeContainsTest
{
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
    public void GivenNonEmptyDeque_WhenContains_ThenItemIsContained(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var deque = testCaseData.Deque;
        //Act (When)
        var actualItem = deque.Contains(testCaseData.ExpectedItem);
        //Assert (Then)
        actualItem.Should().BeTrue();
    }
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
    public void GivenNonEmptyDeque_WhenContains_ThenItemIsNotContained(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var deque = testCaseData.Deque;
        //Act (When)
        var actualItem = deque.Contains(0);
        //Assert (Then)
        actualItem.Should().BeFalse();
    }
    
}
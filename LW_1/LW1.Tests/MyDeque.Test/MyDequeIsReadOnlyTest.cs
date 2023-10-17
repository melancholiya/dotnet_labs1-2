using FluentAssertions;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

namespace LW1.Tests;

[TestFixture]
public class MyDequeIsReadOnlyTest
{
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
    public void MyDequeIsReadOnly(TestCaseData testCaseData)
    {
        //Arrange
        var deque = testCaseData.Deque;
        //Act
        var isReadOnly = deque.IsReadOnly; 
        //Assert
        isReadOnly.Should().BeFalse();
       
    }
}
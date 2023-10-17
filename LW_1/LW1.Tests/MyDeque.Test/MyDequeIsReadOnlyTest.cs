using FluentAssertions;
using NUnit.Framework;

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
        bool isReadOnly = deque.IsReadOnly; 
        //Assert
        isReadOnly.Should().BeFalse();
       
    }
}
using System;
using FluentAssertions;
using LW1.MyCollection;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

namespace LW1.Tests;

[TestFixture]
public class MyDequeCopyToTest
{
    [Test]
    public void CopyTo_NullArray_ShouldThrowArgumentNullException()
    {
        // Arrange
        var deque = new DoubleEndedQueue<int>();
        var array = (int[])null;
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => deque.CopyTo(array, 0));
    }
    [Test]
    public void CopyTo_NegativeArrayIndex_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        var deque = new DoubleEndedQueue<int>();
        var array = new int[5];
        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => deque.CopyTo(array, -1));
    }

    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
    public void CopyTo_InsufficientArraySpace_ShouldThrowArgumentException(TestCaseData testData)
    {
        // Arrange
        var deque = testData.Deque;
        var array = new int[1];
        // Act and Assert
        Assert.Throws<ArgumentException>(() => deque.CopyTo(array, 0));
    }

    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForCopyToMethod))]
    public void CopyTo_ValidArray_ShouldCopyElements(TestCaseData testData)
    {
        // Arrange
        var deque = testData.Deque;
        var array = testData.Array;
        // Act}
        deque.CopyTo(array, 1);
        // Assert
        array.Should().ContainInOrder(testData.ExpectedArray);
    }

}

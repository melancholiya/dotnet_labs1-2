using FluentAssertions;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

namespace LW1.Tests.RemoveTests
{
    [TestFixture]
    public class MyDequeRemoveTest
    {
        //remove should return true if item is in deque
        [Test,TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void Remove_ExistingItem_ShouldRemoveAndReturnTrue(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(testCaseData.ExpectedItem);
            //Assert
            actualResult.Should().BeTrue();
        }
        //remove should return false if item is not in deque
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
        public void Remove_NonExistingItem_ShouldReturnFalse(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(2);
            //Assert
            actualResult.Should().BeFalse();
        }
        //remove head should return true if deque is not empty
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
        public void Remove_Head_ShouldReturnTrue(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(1);
            //Assert
            actualResult.Should().BeTrue();
            deque.Head.Value.Should().Be(2);
        }
        //remove tail should return true if deque is not empty
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
        public void Remove_Tail_ShouldReturnTrue(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(4);
            //Assert
            actualResult.Should().BeTrue();
            deque.Tail.Value.Should().Be(3);
        }
        //remove middle should return true if deque is not empty
        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
        public void Remove_Middle_ShouldReturnTrue(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(2);
            //Assert
            actualResult.Should().BeTrue();
            deque.Tail.Value.Should().Be(4);
            deque.Head.Value.Should().Be(1);
        }
        
    }
}
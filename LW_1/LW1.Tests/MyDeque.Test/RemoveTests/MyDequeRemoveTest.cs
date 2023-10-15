using FluentAssertions;
using NUnit.Framework;

namespace LW1.Tests
{
    [TestFixture]
    public class MyDequeRemoveTest
    {
        [Test]
        [TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithValues))]
        public void Remove_ExistingItem_ShouldRemoveAndReturnTrue(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            var actualResult = deque.Remove(testCaseData.ExpectedItem);
            //Assert
            actualResult.Should().BeTrue();
        }

        [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithOneElement))]
        public void Remove_NonExistingItem_ShouldReturnFalse(TestCaseData testCaseData)
        {
            //Arrange
            var deque = testCaseData.Deque;
            //Act
            bool actualResult = deque.Remove(2);
            //Assert
            actualResult.Should().BeFalse();
        }
    }
}
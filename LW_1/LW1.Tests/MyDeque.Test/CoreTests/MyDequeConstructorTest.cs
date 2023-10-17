using System;
using System.Collections.Generic;
using LW1.MyCollection;
using NUnit.Framework;

namespace LW1.Tests;
[TestFixture]
public class MyDequeConstructorTest
{
    [Test]
    public void Constructor_WithNullCollection_ShouldThrowArgumentNullException()
    {
        // Arrange
        IEnumerable<int>collection = null;
        // Act and Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>(collection);
        });
    }
    [Test]
    public void Constructor_WithValidCollection_ShouldInitializeDequeWithCollectionItems()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3 };
        // Act
        var deque = new DoubleEndedQueue<int>(collection);
        // Assert
        CollectionAssert.AreEqual(collection, deque, "Constructor should initialize the deque with the items from the collection.");
    }
}
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
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentNullException>(() =>
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>(null);
        }, "Constructor should throw ArgumentNullException with a null collection.");
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
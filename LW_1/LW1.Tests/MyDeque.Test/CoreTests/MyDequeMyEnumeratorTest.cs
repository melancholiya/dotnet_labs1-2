using System;
using System.Collections.Generic;
using FluentAssertions;
using LW1.MyCollection;
using LW1.Tests.DataContext;
using NUnit.Framework;
using TestCaseData = LW1.Tests.DataContext.TestCaseData;

namespace LW1.Tests;
[TestFixture]
public class MyDequeMyEnumeratorTest
{
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesForEnumerator))]
    public void MyEnumerator_MoveNext_EnumeratesQueueElements(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var deque = testCaseData.Deque;
        var actualItems = new List<int>();
        //Act (When)
        using var enumerator = deque.GetEnumerator();
        while (enumerator.MoveNext())
        {
            actualItems.Add(enumerator.Current);
        }
        //Assert (Then)
        CollectionAssert.AreEqual(new List<int>{1,2,3,4}, actualItems);
    }
    [Test, TestCaseSource(typeof(ObjectTestData), nameof(ObjectTestData.GetTestCasesWithEmptyCollections))]
    public void MyEnumerator_MoveNext_WhenCollectionIsEmpty_ThenReturnsFalse(TestCaseData testCaseData)
    {
        //Arrange (Given)
        var deque = testCaseData.Deque;
        //Act (When)
        using var enumerator = deque.GetEnumerator();
        //Assert (Then)
        Assert.IsFalse(enumerator.MoveNext());
    }
   

}
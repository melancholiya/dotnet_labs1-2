using System;
using System.Collections.Generic;
using LW1.MyCollection;

namespace LW1.Tests
{
    public class ObjectTestData
    {

        public static IEnumerable<TestCaseData> GetTestCasesWithValues()
        {
            yield return new TestCaseData(new DoubleEndedQueue<int>{1},1);
            yield return new TestCaseData(new DoubleEndedQueue<int>{1,2,3,4},1);
        }

        public static IEnumerable<TestCaseData> GetTestCasesWithEmptyCollections()
        {
            yield return new TestCaseData( new DoubleEndedQueue<int>());
        }

        public static IEnumerable<TestCaseData> GetTestCasesWithOneElement()
        {
            yield return new TestCaseData(new DoubleEndedQueue<int>{1},1);
        }

        public static IEnumerable<TestCaseData> GetTestCasesForCopyToMethod()
        {
            yield return new TestCaseData(new DoubleEndedQueue<int>{1,2,3,4},new int[6],new int[]{0,1,2,3,4});
        }
        public static IEnumerable<TestCaseData>GetTestCasesForEnumerator()
        {
            yield return new TestCaseData(new DoubleEndedQueue<int>{1,2,3,4});
        }
    }

    public class TestCaseData
    {
        public DoubleEndedQueue<int> Deque { get; set; }
        public int ExpectedItem { get; set; }
        public int[] Array { get; set; }
        public int []ExpectedArray { get; set; }
        
        public TestCaseData(DoubleEndedQueue<int> deque, int expectedItem)
        {
            Deque = deque;
            ExpectedItem = expectedItem;
        }

        public TestCaseData(DoubleEndedQueue<int> deque)
        {
            Deque = deque;
        }

        public TestCaseData(DoubleEndedQueue<int> deque, int[] array, int[] expectedArray)
        {
            Deque = deque;
            Array = array;
            ExpectedArray = expectedArray;
        }
       
    }

}


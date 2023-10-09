using System.Collections.Generic;

namespace LW1.Tests
{
    public class ObjectTestData
    {
        public static object[] TestCasesWithValues =
        {
            new object[] { 42,56,56 },
            new object[] { "Alice", "Bob", "Bob" },
            new object[] { true, false, false },
            new object[] { new MyClassA { Value = 42 }, new MyClassA { Value = 56 }, new MyClassA { Value = 56 } },
            new object[] { new MyClassB { Name = "Alice" }, new MyClassB { Name = "Bob" }, new MyClassB { Name = "Bob" } },
        };
        public static object[] TestCasesWithEmptyCollections =
        {
            new object[] { new List<int>(), 42 },
            new object[] { new List<string>(), "Alice" },
            new object[] { new List<bool>(), true },
            new object[] { new List<MyClassA>(), new MyClassA { Value = 42 } },
            new object[] { new List<MyClassB>(), new MyClassB { Name = "Alice" } },
        };

        private class MyClassA
        {
            public int Value { get; set; }
        }

        private class MyClassB
        {
            public string Name { get; set; }
        }
    }
}
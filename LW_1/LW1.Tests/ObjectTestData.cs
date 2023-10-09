namespace LW1.Tests
{
    public class ObjectTestData
    {
        public static object[] TestCases =
        {
            new object[] { 42,56,56 },
            new object[] { "Alice", "Bob", "Bob" },
            new object[] { true, false, false },
            new object[] { new MyClassA { Value = 42 }, new MyClassA { Value = 56 }, new MyClassA { Value = 56 } },
            new object[] { new MyClassB { Name = "Alice" }, new MyClassB { Name = "Bob" }, new MyClassB { Name = "Bob" } },
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
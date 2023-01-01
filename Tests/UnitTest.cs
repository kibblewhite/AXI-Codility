namespace Tests;

[TestClass]
public class UnitTest
{
    [TestMethod]
    [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
    public void TestMethod(string display_name, string input, string expected)
    {
        Console.WriteLine($" > {display_name}");
        string results = Solution.solution(input);
        Assert.AreEqual(expected, results);
    }

    [TestMethod]
    [DynamicData(nameof(TestDataSet.GenerateBasicDataSet), typeof(TestDataSet), DynamicDataSourceType.Method)]
    public void TestSimpleMethod(string display_name, string input, string expected)
    {
        Console.WriteLine($" > {display_name}");
        string results = Solution.simple_solution(input);
        Assert.AreEqual(expected, results);
    }
}

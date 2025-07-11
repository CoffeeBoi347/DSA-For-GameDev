using NUnit.Framework;
public class ParameterizedTests
{
    [TestCase(2,3, 5)]
    [TestCase(5,3,8)]
    [TestCase(5,5,10)]
    public void AddNumbers_ReturnsCorrectSum(int a, int b, int expected)
    {
        Assert.AreEqual(expected, a + b);
    }
}
namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_WithAnEmptyString_Returns0()
    {
        var result = StringCalculator.Add("");

        Assert.Equal(0, result);
    }
    
    [Fact]
    public void Add_With1_Returns1()
    {
        var result = StringCalculator.Add("1");

        Assert.Equal(1, result);
    }
}

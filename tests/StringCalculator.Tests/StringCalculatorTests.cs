namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_WithAnEmptyString_Returns0()
    {
        var result = StringCalculator.Add("");

        Assert.Equal(0, result);
    }
}

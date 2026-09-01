namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_WithAnEmptyString_Returns0()
    {
        var result = StringCalculator.Add("");

        Assert.Equal("0", result);
    }
    
    [Theory]
    [InlineData("1", "1")]
    [InlineData("2", "2")]
    [InlineData("2.5", "2.5")]
    [InlineData("2,3", "5")]
    [InlineData("5,2", "7")]
    [InlineData("4,5,2", "11")]
    [InlineData("1.1,2.2", "3.3")]
    public void Add_WithCommaSeparatedNumbers_ReturnsSumOfNumbers(string input, string expected)
    {
        var result = StringCalculator.Add(input);

        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Add_WithLineSeparatedNumbers_ReturnsSumOfNumbers()
    {
        var result = StringCalculator.Add("2.2\n4.4");

        Assert.Equal("6.6", result);
    }
    
    [Fact]
    public void Add_WithLineAndCommaSeparatedNumbers_ReturnsSumOfNumbers()
    {
        var result = StringCalculator.Add("1\n2,3");

        Assert.Equal("6", result);
    }
}

// implement unit test theory https://pgpott.medium.com/theory-vs-fact-attribute-c-xunit-testing-9cd3c6bae76f

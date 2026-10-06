namespace StringCalculator.Tests;

public class StringCalculatorTests
{
    [Fact]
    public void Add_WithAnEmptyString_Returns0()
    {
        Assert.Equal("0", StringCalculator.Add(""));
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
        Assert.Equal(expected, StringCalculator.Add(input));
    }
    
    [Fact]
    public void Add_WithLineSeparatedNumbers_ReturnsSumOfNumbers()
    {
        Assert.Equal("6.6", StringCalculator.Add("2.2\n4.4"));
    }
    
    [Fact]
    public void Add_WithLineAndCommaSeparatedNumbers_ReturnsSumOfNumbers()
    {
        Assert.Equal("6", StringCalculator.Add("1\n2,3"));
    }

    [Fact]
    public void Add_DoesntAllowTheInputToEndInASeparator()
    {
        Assert.Equal(
            "Number expected but EOF found",
            StringCalculator.Add("1,3,")
        );
    }

        [Fact]
    public void Add_WithCustomSeparatorDoesntAllowInvalidSeparators()
    {
        Assert.Equal(
            "'|' expected but ',' found at position 3.", 
            StringCalculator.Add("//|\n1|2,3")
        );
    }
    
    [Theory]
    [InlineData("//;\n1;2", "3")]
    [InlineData("//|\n1|2|3", "6")]
    [InlineData("//sep\n2sep3", "5")]
    public void Add_WithCustomSeparator_ReturnsSumOfNumbers(string input, string expected)
    {
        Assert.Equal(expected, StringCalculator.Add(input));
    }
    
    [Theory]
    [InlineData("-1,2", "Negative not allowed : -1")]
    // [InlineData("2,-4,-5", "Negative not allowed : -4, -5")]
    public void Add_DoesNotAllowNegativeNumbers(string input, string expected)
    {
        Assert.Equal(expected, StringCalculator.Add(input));
    }
}

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

    [Fact]
    public void Add_With2_Returns2()
    {
        var result = StringCalculator.Add("2");

        Assert.Equal(2, result);
    }

    [Fact]
    public void Add_With2point5_Returns2point5()
    {
        var result = StringCalculator.Add("2.5");

        Assert.Equal(2.5, result);
    }

    [Fact]
    public void Add_With2and3_Returns5()
    {
        var result = StringCalculator.Add("2,3");

        Assert.Equal(5, result);
    }

    [Fact]
    public void Add_With5and2_Returns7()
    {
        var result = StringCalculator.Add("5,2");

        Assert.Equal(7, result);
    }

    [Fact]
    public void Add_With4and5and2_Returns11()
    {
        var result = StringCalculator.Add("4,5,2");

        Assert.Equal(11, result);
    }
}

// implement unit test theory https://pgpott.medium.com/theory-vs-fact-attribute-c-xunit-testing-9cd3c6bae76f

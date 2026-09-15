namespace StringCalculator;

public static class StringCalculator
{
    public static string Add(string input)
    {
        if (input == "")
        {
            return "0";
        }

        if (input.EndsWith(","))
        {
            return "Number expected but EOF found";
        }

        return input
            .Split('\n', ',')
            .Select(decimal.Parse)
            .ToArray()
            .Sum()
            .ToString();
    }
}

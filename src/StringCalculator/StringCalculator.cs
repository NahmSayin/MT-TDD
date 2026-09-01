namespace StringCalculator;

public static class StringCalculator
{
    public static string Add(string input)
    {
        if (input == "")
        {
            return "0";
        }

        return input
            .Split('\n', ',')
            .Select(decimal.Parse)
            .ToArray()
            .Sum()
            .ToString();
    }
}

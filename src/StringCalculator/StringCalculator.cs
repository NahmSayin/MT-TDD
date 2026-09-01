namespace StringCalculator;

public static class StringCalculator
{
    public static string Add(string input)
    {
        if (input == "")
        {
            return "0";
        }

        string separator = ",";
        if (input.Contains("\n")) {
            separator = "\n";
        }
        return input
            .Split(separator)
            .Select(decimal.Parse)
            .ToArray()
            .Sum()
            .ToString();
    }
}

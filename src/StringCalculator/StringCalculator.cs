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

        if (input.StartsWith("//"))
        {
            string[] inputParts = input.Substring(2).Split('\n');
            string seperator = inputParts[0];
            return inputParts[1].Split(seperator)
                .Select(decimal.Parse)
                .ToArray()
                .Sum()
                .ToString();
        }

        return input
            .Split('\n', ',')
            .Select(decimal.Parse)
            .ToArray()
            .Sum()
            .ToString();
    }
}
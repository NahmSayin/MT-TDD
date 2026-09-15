namespace StringCalculator;

public class StringCalculator
{
    private static string customSeparatorIndicator = "//";

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

        string[] separators = ["\n", ","];


        if (input.StartsWith(StringCalculator.customSeparatorIndicator))
        {
            string[] inputParts = input.Substring(2).Split('\n');
            separators = [inputParts[0]];
            input = inputParts[1];
        }

        return input
            .Split(separators, StringSplitOptions.None)
            .Select(decimal.Parse)
            .ToArray()
            .Sum()
            .ToString();
    }
}
namespace StringCalculator;

public class StringCalculator
{
    private static string customSeparatorIndicator = "//";

    public static string Add(string input)
    {
        try
        {
            if (input == "")
            {
                return "0";
            }

            CheckInputDoesNotEndWithComma(input);

            string[] separators = ["\n", ","];

            (input, separators) = HandleCustomSeparators(input, separators);

            string[] strings = input
                .Split(separators, StringSplitOptions.None);

            CheckForInvalidSeparators(input, strings, separators);

            IEnumerable<decimal> numbers = strings
                .Select(decimal.Parse);

            return numbers
                .ToArray()
                .Sum()
                .ToString();
        }
        catch (Exception error)
        {
            return error.Message;
        }
    }

    private static (string input, string[] separators) HandleCustomSeparators(string input, string[] separators)
    {
        if (input.StartsWith(StringCalculator.customSeparatorIndicator))
        {
            string[] inputParts = input.Substring(2).Split('\n');
            separators = [inputParts[0]];
            input = inputParts[1];
        }

        return (input, separators);
    }

    private static void CheckInputDoesNotEndWithComma(string input)
    {
        if (input.EndsWith(","))
        {
            throw new Exception("Number expected but EOF found");
        }
    }

    private static void CheckForInvalidSeparators(string input, string[] strings, string[] separators)
    {
        if (Array.Exists(strings, element => element.Contains(",")))
        {
            int position = input.IndexOf(",");
            throw new Exception($"'{separators[0]}' expected but ',' found at position {position}.");
        }
    }
}

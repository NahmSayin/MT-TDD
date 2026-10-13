namespace StringCalculator;

public class StringCalculator
{
    private static string _customSeparatorIndicator = "//";

    public static string Add(string input)
    {
        try
        {
            if (input == "")
            {
                return "0";
            }

            string[] separators = ["\n", ","];

            (input, separators) = HandleCustomSeparators(input, separators);

            string[] strings = input
                .Split(separators, StringSplitOptions.None);

            ValidateInput(input, strings, separators);

            return ConvertStringsToNumbers(strings)
                .ToArray()
                .Sum()
                .ToString();
        }
        catch (Exception error)
        {
            return error.Message;
        }
    }

    private static void ValidateInput(string input, string[] strings, string[] separators)
    {
        string[] errors = [];

        try
        {
            CheckInputDoesNotEndWithComma(input);
        }
        catch (Exception error)
        {
            errors.Append(error.Message);
        }

        try
        {
            CheckForInvalidSeparators(input, strings, separators);
        }
        catch (Exception error)
        {
            errors.Append(error.Message);
        }

        try
        {
            CheckForNegativeNumbers(strings);
        }
        catch (Exception error)
        {
            errors.Append(error.Message);
        }

        if (errors.Length > 0)
        {
            throw new Exception(string.Join("\n", errors));
        }
    }

    private static IEnumerable<decimal> ConvertStringsToNumbers(string[] strings)
    {
        IEnumerable<decimal> numbers = strings
            .Select(decimal.Parse);
        return numbers;
    }

    private static (string input, string[] separators) HandleCustomSeparators(string input, string[] separators)
    {
        if (input.StartsWith(StringCalculator._customSeparatorIndicator))
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

    private static void CheckForNegativeNumbers(string[] strings)
    {
        // Todo: remove empty strings before converting to decimals
        decimal[] negativeNumbers = ConvertStringsToNumbers(strings)
            .Where(n => n < 0).ToArray();

        if (negativeNumbers.Length > 0)
        {
            throw new Exception($"Negative not allowed : {string.Join(", ", negativeNumbers)}");
        }
    }
}

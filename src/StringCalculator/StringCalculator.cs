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

        string[] strings = input
            .Split(separators, StringSplitOptions.None);

        if (Array.Exists(strings, element => element.Contains(",")))
        {
            int position = input.IndexOf(",");
            return $"'{separators[0]}' expected but ',' found at position {position}.";
        }
        
        IEnumerable<decimal> numbers = strings
            .Select(decimal.Parse);
        
        return numbers
            .ToArray()
            .Sum()
            .ToString();
    }
}

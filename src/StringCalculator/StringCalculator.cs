namespace StringCalculator;

public static class StringCalculator
{
    public static float Add(string input)
    {
        if (input == "")
        {
            return 0;
        }

        return float.Parse(input);
    }
}

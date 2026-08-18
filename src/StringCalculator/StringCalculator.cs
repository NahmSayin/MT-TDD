namespace StringCalculator;

public static class StringCalculator
{
    public static float Add(string input)
    {
        if (input == "")
        {
            return 0;
        }
        float[] splitInput = input.Split(',').Select(float.Parse).ToArray();
        return splitInput.Sum();
    }
}

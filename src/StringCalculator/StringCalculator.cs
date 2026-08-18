namespace StringCalculator;

public static class StringCalculator
{
    public static float Add(string input)
    {
        if (input == "")
        {
            return 0;
        }
        
        if (input.Contains(','))
        {
            float[] splitInput = input.Split(',').Select(float.Parse).ToArray();
            return splitInput[0] + splitInput[1];
        }
        
        return float.Parse(input);
    }
}

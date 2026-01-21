using System;
class Program
{
    public static void Main()
    {
        string[] tokens = { "10", "abc", "20", "9999999999", "-5" };

        int result = SumValidIntegers(tokens);


        Console.WriteLine(result);

    }
    public static int SumValidIntegers(string[] tokens)
    {
        int sum = 0;

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int value))
            {
                sum += value;
            }
        }

        return sum;
    }

}
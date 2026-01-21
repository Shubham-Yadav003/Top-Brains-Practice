class Program
{
    public static void Main()
    {

        double output = helper();
        Console.WriteLine($"Output is: {output}");

    }

    public static double helper()
    {
        int Feet = int.Parse(Console.ReadLine());
        if (Feet < 0 || Feet > int.MaxValue)
        {
            Console.WriteLine("Invalid Feet Value");
            return 0;
        }

        double res = Math.Round(30.48 * Feet, MidpointRounding.AwayFromZero);
        return res;

    }
}
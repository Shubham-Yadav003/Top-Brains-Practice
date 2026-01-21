class Program
{
    public static void Main()
    {

        double output = helper();
        Console.WriteLine($"Output is: {output}");

    }

    public static double helper()
    {
        double val = double.Parse(Console.ReadLine());
        if (radius < 0 || radius > double.MaxValue)
        {
            Console.WriteLine("Invalid radius");
            return;
        }

        double res = Math.Round(3.14 * val * val, MidpointRounding.AwayFromZero);
        return res;

    }
}
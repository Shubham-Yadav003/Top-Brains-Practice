class Program
{
    public static void Main()
    {
        double output = CalculateCircleArea();
        Console.WriteLine(output);
    }

    public static double CalculateCircleArea()
    {
        double radius = double.Parse(Console.ReadLine());

        if (radius < 0 || radius > 1e6)
        {
            Console.WriteLine("Invalid radius");
            return 0;
        }

        double area = Math.PI * radius * radius;
        double rounded = Math.Round(area, 2, MidpointRounding.AwayFromZero);
        return rounded;
    }
}
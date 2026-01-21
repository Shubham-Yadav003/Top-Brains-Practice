using System;

class Program
{
    static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }

    static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        a = a + b;
        b = a - b;
        a = a - b;

        x = a;
        y = b;
    }

    static void Main()
    {
        int a = 10, b = 20;
        SwapUsingRef(ref a, ref b);
        Console.WriteLine($"{a} {b}");

        int x, y;
        SwapUsingOut(30, 40, out x, out y);
        Console.WriteLine($"{x} {y}");
    }
}

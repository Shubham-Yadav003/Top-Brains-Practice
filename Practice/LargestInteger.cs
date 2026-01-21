using System;
class Program
{
    public static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        int largest = FindLargest(a, b, c);
        Console.WriteLine(largest);
    }

    // Method to find the largest of three integers
    // Input: a, b, c (integers in range -1e9 to 1e9)
    // Output: largest integer among the three
    public static int FindLargest(int a, int b, int c)
    {
        if (a > b && a > c)
        {
            return a;
        }
        else if (b > a && b > c)
        {
            return b;
        }
        else
        {
            return c;
        }
    }
}
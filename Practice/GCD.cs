using System;
public class GCD
{
  public static int FindGCD(int a, int b)
  {
    if (b == 0) return a;
    return FindGCD(b, a % b);
  }
  public static void Main()
  {
    int.TryParse(Console.ReadLine(), out int a);
    int.TryParse(Console.ReadLine(), out int b);
    int gcd = FindGCD(a, b);
    System.Console.WriteLine(gcd);
  }
}
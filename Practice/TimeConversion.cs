using System;
public class Program
{
    public static void Main()
    {
        Console.Write("Enter totalSeconds: ");
        int totalSeconds = Convert.ToInt32(Console.ReadLine());
        string min = (totalSeconds / 60).ToString();
        string sec = (totalSeconds % 60).ToString().PadLeft(2,'0');
        Console.WriteLine($"{min}:{sec}");
    }
}
using System;
class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int upto = int.Parse(Console.ReadLine());
        int[] res = MultiplicationRow(n,upto);
        foreach(var val in res)
        {
            Console.Write(val + " ");
        }

    }

    public static int[] MultiplicationRow(int n, int upto)
{
    int[] result = new int[upto];

    for (int i = 1; i <= upto; i++)
    {
        result[i - 1] = n * i;
    }

    return result;
}

}
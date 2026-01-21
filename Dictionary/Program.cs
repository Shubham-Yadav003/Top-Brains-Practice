using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(1, 20000);
        dict.Add(4, 40000);
        dict.Add(5, 15000);

        List<int> list = new List<int>();
        list.Add(1);
        list.Add(4);
        list.Add(5);

        int res = 0;
        foreach (var val in list)
        {
            if (dict.ContainsKey(val))
            {
                res += dict[val]; // value
            }
        }
        Console.WriteLine($"Sum is: {res}");
    }
}
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        dict.Add(1, 10000);
        dict.Add(2, 20000);
        dict.Add(3, 30000);

        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

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
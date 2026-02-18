using System;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Input:");
        string input = Console.ReadLine();

        string[] arr = input.Split(",");
        
        List<float> list = new List<float>();
        foreach(var elem in arr)
        {
            if(float.TryParse(elem, out float value) )
            {
                if(!float.IsNaN(value))
                list.Add(Convert.ToSingle(Math.Round(value,2)));
            }
        }

       
            Console.Write(string.Join(", ", list.Select(x=>x.ToString("0.00"))));
        
    }
}
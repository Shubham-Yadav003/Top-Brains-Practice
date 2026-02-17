using System.Text;

class Program
{
    public static void Main()
    {
        Dictionary<int, bool?> dict = new Dictionary<int, bool?>();
        
        Console.WriteLine("Enter input string:");
        string input = Console.ReadLine();

        string[] arr1 = input.Split(",");

        // string newString = string.Join("", arr1);

        // string[] arr2 = arr1.Split(":");

       foreach(var elem in arr1)
        {
           string[] ip = elem.Split(":");
           if(int.TryParse(ip[0] , out int res)){
                if(ip[1] == "Present")
                {
                    dict.Add(res, true);
                }
                else if(ip[1] == "Absent")
                {
                    dict.Add(res, false);
                }
                else
                {
                    dict.Add(res, null);
                }
            }
        }
        // dictionary is ready
        int presentCount = 0;
        int absentCount = 0;
        int notMarked = 0;
        foreach(var elem in dict)
        {
            if(elem.Value == true)
            {
                presentCount++;
            }
            else if(elem.Value == false)
            {
                absentCount++;
            }
            else
            {
               notMarked++; 
            }
        }

        foreach(var elem in dict)
        {
            if(elem.Value == true)
            {
                string present = "Present";
                Console.WriteLine($"{elem.Key} -> {present}");
            }
            else if(elem.Value == false)
            {
                 string absent = "Absent";
                Console.WriteLine($"{elem.Key} -> {absent}");
            }
            else
            {
              Console.WriteLine($"{elem.Key} -> Not Marked");  
            }
        }

        Console.WriteLine($"Total Present: {presentCount}");
        Console.WriteLine($"Total Absent: {absentCount}");
        Console.WriteLine($"Not Marked: {notMarked}");





    }
}
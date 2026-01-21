class Program
{
    public static void Main()
    {
        // Console.WriteLine("Enter a unique string");
        string str = " llapppptop bag ";

        // case1: remove consequtive duplicates
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (str[i] == str[i + 1])
            {
                str = str.Remove(i, 1);
                i--;
            }
        }

        // trim extra space
        str = str.Trim();
        str = str.ToLower();

        // ToTitle case
        //     int idx = 0;
        //     string res = "";
        //     while (idx < str.Length)
        //     {
        //         if (idx == 0)
        //         {
        //             res += char.ToUpper(str[idx]);
        //             idx++;
        //         }
        //         while (idx < str.Length && str[idx] == ' ') { idx++; }

        //         if (idx < str.Length && str[idx] != ' ' && idx > 0 && str[idx - 1] == ' ')
        //         {
        //             res += ' ';
        //             res += char.ToUpper(str[idx]);
        //             idx++;
        //         }

        //         else if (idx < str.Length)
        //         {
        //             res += str[idx];
        //             idx++;
        //         }
        //     }

        //     Console.WriteLine($"RESULT IS: {res}");

        // ***************//
        // using inbuilt 
        string res = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        Console.WriteLine($"RESULT IS: {res}");
    }
}
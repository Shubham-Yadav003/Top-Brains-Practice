using System;
class StringManip
{
    public static void Main()
    {
        string input1 = "abccde";
        string input2 = "ibmmo";

        // case removve common consonants !!
        foreach (char ch in input2)
        {
            if (!IsVowel(ch))
            {
                input1 = input1.Replace(ch.ToString(), "");
            }
        }

        // remove consequtive duplicate characters
        // for(int i=0;i<input1.Length - 1; i++)
        // {
        //     if(input1[i] == input1[i + 1])
        //     {
        //         input1 =  input1.Remove(i,1);
        //         i--;
        //     }
        // }

        string result = "";
        foreach (char ch in input1)
        {
            if (result.Length == 0 || result[result.Length - 1] != ch)
            {
                result += ch;
            }
        }
        Console.WriteLine($"Input1: {input1}");
        Console.WriteLine($"Input2: {input2}");
        Console.WriteLine($"Result: {result}");
    }

    public static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }
}
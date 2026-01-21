using System;
class Program
{
    public static void Main()
    {
        int[] nums = new int[] {1,2,3,4,5,6,7,8,9,0};
        int res=0;
        for(int i = 0; i < arr.Length; i++)
        {
            if(nums[i]<0) continue;
            else if(nums[i] == 0) break;
            else
            {
                res += nums[i];
            }
        }

        Console.WriteLine(res);
    }
}
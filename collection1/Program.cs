using System;

class Activity
{
    public void Helper()
    {
         int noOfStd = 0;
         noOfStd = int.Parse(Console.ReadLine());
         int[] arr = new int[noOfStd];
        
        int highest = int.MinValue;
         
        for(int i = 0; i < noOfStd; i++)
        {
            arr[i] = int.Parse(Console.ReadLine()); 
            
            if(arr[i] > highest)
            {
                highest = arr[i];
            }
        }

        for(int i = 0; i < noOfStd; i++)
        {
            int normalized = arr[i]*100 / highest;
            arr[i] = normalized;
        }

        foreach(var val in arr)
        {
            Console.Write(val + " ");
        }
    }
}

class Program
{
    public static void Main()
    {
        Activity obj = new Activity();
        obj.Helper();
    }
}
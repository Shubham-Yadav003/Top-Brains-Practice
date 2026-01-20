// using System;
// class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter a start number:");
//         int start = int.Parse(Console.ReadLine());

//         Console.WriteLine("Enter a end number:");
//         int end = int.Parse(Console.ReadLine());
//         // a non prime positive integer -> lucky number
//         int cnt = 0;
//         for (int i = start + 1; i < end; i++)
//         {
//             if (IsNonPrimePositive(i))
//             {
//                 int sqrNumber = i * i;
//                 int sum = helper(sqrNumber);
//                 if (sum == sqrNumber) cnt++;
//             }

//         }
//         Console.WriteLine($"Number of Non prime positive integers are: {cnt}");
//     }

//     public static bool IsNonPrimePositive(int num)
//     {
//         if (num <= 1) return false;
//         for (int i = 2; i <= Math.Sqrt(num); i++)
//         {
//             if (num % i == 0) return true;
//         }
//         return false;
//     }

   
//     public static int helper(int num)
//     {
//        int sum = 0;
//         while (num != 0)
//         {
//             int val = num % 10;
//             sum += val;
//             num = num / 10;
//         }

//         return sum;
//     }
// }
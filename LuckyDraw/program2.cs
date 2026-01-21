class Program2
{
    public static void Main()
    {

        int start = int.Parse(Console.ReadLine());


        int end = int.Parse(Console.ReadLine());

        //formula -> Sum of(i^2) == sum of(i) * sum of(i);
        int cnt = 0;
        for (int i = start; i <= end; i++)
        {
            if (IsNonPrimePositive(i))
            {
                int case1 = Summation(i * i);
                int case2 = Summation(i) * Summation(i);

                if (case1 == case2)
                {
                    Console.WriteLine(i);
                    cnt++;
                }
            }
        }
        Console.WriteLine($"{cnt}");
    }


    public static int Summation(int num)
    {
        int sum = 0;
        while (num != 0)
        {
            int val = num % 10;
            sum += val;
            num = num / 10;
        }

        return sum;
    }

    public static bool IsNonPrimePositive(int num)
    {
        if (num <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0) return true;
        }
        return false;
    }
}
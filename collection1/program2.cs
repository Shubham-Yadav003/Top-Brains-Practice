class Program
{
    public static void Main()
    {
        int noOfClass = int.Parse(Console.ReadLine());
        int noOfDays = int.Parse(Console.ReadLine());
        bool [,] matrix = new bool[noOfClass,noOfDays];

        for(int i = 0; i < noOfClass; i++)
        {
             for(int i = 0; i < noOfDays; i++)
            {
                matrix[i,j] = bool.Parse(Cosnole.ReadLine());
            }
        }



    }
}
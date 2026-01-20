using System.Collections.Generic;
class program
{
    public static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student {Name = "Krishna", Age = 100, Marks = 20},
            new Student {Name = "Shubham", Age = 100, Marks = 10},
            new Student {Name = "Alto", Age = 200, Marks = 30}
        };

        students.Sort(); // compare to persormaed internally

        foreach (var val in students)
        {
            Console.WriteLine(val);
        }
    }
}
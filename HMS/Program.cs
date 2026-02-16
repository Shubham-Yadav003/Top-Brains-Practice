public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }
}

public class HospitalManager
{
    private Dictionary<int, Patient> dict = new Dictionary<int, Patient>();
    private Queue<Patient> queue = new Queue<Patient>();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        // TODO: Create patient and add to dictionary
        Patient obj = new Patient()
        {
            Id = id,
            Name = name,
            Age = age,
            Condition = condition

        };
        dict.Add(id, obj);

    }


    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue
        foreach (var elem in dict)
        {
            if (elem.Key == patientId)
            {
                queue.Enqueue(elem.Value);
            }
        }

    }


    public Patient ProcessNextAppointment()
    {
        // TODO: Return and remove next patient from queue
        if(queue.Count != null){ 
        var result = queue.Peek();
        queue.Dequeue();

        return result;
        }
        else
        {
            return null;
        }

        

    }


    public List<Patient> FindPatientsByCondition(string condition)
    {
        // TODO: Use LINQ to filter patients
        // List<Patient> res = new List<Patient>();
        // foreach (var elem in dict)
        // {
        //     if (elem.Value.Condition == "Diabetes")
        //     {
        //         res.Add(elem.Value);
        //     }
        // }  
        // return res;

        return dict.Values.
            Where(x => x.Condition == condition)
            .ToList();
    }


}

class Program
{
    public static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name); // Should output: John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count); // Should output: 1
    


    }
}
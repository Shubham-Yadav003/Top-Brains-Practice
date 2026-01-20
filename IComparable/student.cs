class Student : IComparable<Student>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }

    public override string ToString()
    {
        return $"Name: {Name} Id:{Age} Marks: {Marks}";
    }

    public int CompareTo(Student other)
    {
        if (other == null) return 1;

        int res = other.Age.CompareTo(this.Age); // descending
        if (res != 0) return res;

        return this.Marks.CompareTo(other.Marks); // ASCENDING

    }
}
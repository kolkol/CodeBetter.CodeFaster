using static Models.Constants;

namespace Models
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }

        public bool IsValid { get; set; }

        public int Age { get; set; } = 0;
        public int Birthday { get; set; } = 0;

        public AcademicLevel Level { get; set; }

    }

    public class Student : Person
    {
        public Student(string name) : base(name)
        {
        }
    }

    public class Lecturer : Person
    {
        public Lecturer(string name) : base(name)
        {
        }
    }
}
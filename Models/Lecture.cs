using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Lecture
    {
        public Lecture(List<Person> registeredStudents)
        {
            RegisteredStudents = registeredStudents;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public Person Lecturer { get; set; }

        public List<Person> Attendees { get; set; }

        public List<Person> RegisteredStudents { get; set; }

        public ClassRoom Location { get; set; }


    }
}

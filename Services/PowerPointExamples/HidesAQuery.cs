using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.PowerPointExamples
{
    internal class HidesAQuery
    {
        public static string GetStudentNamesAsString(List<Person> persons)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Person person in persons)
            {
                if(!person.IsValid)
                    continue;

                if (person is Student)
                {
                    sb.Append(person.Name).Append(",");
                }
                else
                {
                    continue;
                }
            }
            return sb.ToString();
        }

        public static string GetStudentNamesAsStringQuery(List<Person> persons)
        {
            //Filter the inparameters first.
            List<Student> students = persons.Where(p => p.IsValid && p is Student).Cast<Student>().ToList();

            StringBuilder sb = new StringBuilder();
            //We know are sure within this method that we have only Students and that they are valid, all in loop if logic can be removed, continue keyword can be removed.
            foreach (Person student in students)
            {
                 sb.Append(student.Name).Append(",");
            }

            return sb.ToString();
        }

    }
}

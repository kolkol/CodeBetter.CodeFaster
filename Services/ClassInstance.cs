using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Constants;

namespace Services
{
    public class ClassInstance
    {
        private List<Student> students;
        private List<Lecturer> lecturers;
        private List<Student> studentsWaitList;
        private int maxStudents;
        private int maxStudentsWaitList;
        private int maxLecturers;
        private int maxSeats;
        private DateTime lastDayToRegister;
        private IObserverConsole observer;
        private AcademicLevel academicLevelRequiredToAttend;
        private AcademicLevel academicLevelRequiredToTeach;



        public ClassInstance(IObserverConsole observer)
        {
            this.observer = observer;
            this.maxStudents = 10;
            this.maxStudentsWaitList = 5;
            this.maxLecturers = 2;
            this.maxSeats = 12;
            lastDayToRegister = DateTime.Now.AddDays(10);
            academicLevelRequiredToAttend = AcademicLevel.None;
            academicLevelRequiredToTeach = AcademicLevel.Bachelor;

            students = new List<Student>();
            studentsWaitList = new List<Student>();
            lecturers = new List<Lecturer>();
        }

        public ClassInstance(IObserverConsole observer, int maxStudents, int maxLecturers, int maxSeats, DateTime lastTimetoRegister, AcademicLevel requiredToAttend, AcademicLevel requiredToTeach)
        {
            this.observer = observer;
            this.academicLevelRequiredToAttend = requiredToAttend;
            this.academicLevelRequiredToTeach = requiredToTeach;

            this.maxStudents = maxStudents;
            this.maxLecturers = maxLecturers;
            this.maxSeats = maxSeats;
            this.lastDayToRegister = lastTimetoRegister; 

            students = new List<Student>();
            studentsWaitList = new List<Student>();
            lecturers = new List<Lecturer>();
        }

        /// <summary>
        /// This is the original complex, unclear and quite bad code.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public bool AddAttendee(Person p, bool isAdmin)
        {
            if(p is Student)
            {
                if(DateTime.Now < lastDayToRegister)
                {
                    if(students.Count < maxStudents)
                    {
                        if ((int)p.Level >= (int)this.academicLevelRequiredToAttend)
                        {
                            students.Add(p as Student);
                        }
                    }
                    else if(studentsWaitList.Count < maxStudentsWaitList)
                    {
                        if((int)p.Level >= (int)this.academicLevelRequiredToAttend)
                        {
                            students.Add(p as Student);
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                
            }
            else if(p is Lecturer)
            {
                if (DateTime.Now < lastDayToRegister)
                {
                    if (lecturers.Count < maxLecturers)
                    {
                        if ((int)p.Level >= (int)this.academicLevelRequiredToTeach)
                        {
                            lecturers.Add(p as Lecturer);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                   return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }


        

    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Constants;

namespace Services
{
    /// <summary>
    /// Problems to solve.
    /// Redudant code, 
    /// Complex code,
    /// Method size over 10 lines.
    /// </summary>
    public class LectureInstance
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

        public LectureInstance(IObserverConsole observer)
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

        public LectureInstance(IObserverConsole observer, int maxStudents, int maxLecturers, int maxSeats, DateTime lastTimetoRegister, AcademicLevel requiredToAttend, AcademicLevel requiredToTeach)
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
        /// If all is well, return true, if something goes wrong, return false.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        public bool AddAttendees(List<Person> p, bool isAdmin)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i] is Student)
                {
                    if (DateTime.Now < lastDayToRegister || isAdmin)
                    {
                        if (students.Count < maxStudents)
                        {
                            if ((int)p[i].Level >= (int)this.academicLevelRequiredToAttend)
                            {
                                students.Add(p[i] as Student);
                            }
                        }
                        else if (studentsWaitList.Count < maxStudentsWaitList)
                        {
                            if ((int)p[i].Level >= (int)this.academicLevelRequiredToAttend)
                            {
                                studentsWaitList.Add(p[i] as Student);
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
                else if (p is Lecturer)
                {
                    if (DateTime.Now < lastDayToRegister || isAdmin)
                    {
                        if (lecturers.Count < maxLecturers)
                        {
                            if ((int)p[i].Level >= (int)this.academicLevelRequiredToTeach)
                            {
                                lecturers.Add(p[i] as Lecturer);
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

            }

            return true;
        }


        

    }
}

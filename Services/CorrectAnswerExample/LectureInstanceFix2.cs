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
    /// Reusable and not redentant - fixed: Constructurs contain alot of redundant code, we can fix this without breaking the calling code, by letting the default constructor rely on the big one.
    /// Complexity fixed: Deep complexity with two bumps. Break into separate handlers.
    /// </summary>
    public class LectureInstanceFix2
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

        public LectureInstanceFix2(IObserverConsole observer) 
            : this(observer, 10, 2, 12, DateTime.Now.AddDays(10), AcademicLevel.None, AcademicLevel.Bachelor)
        { }

        public LectureInstanceFix2(IObserverConsole observer, int maxStudents, int maxLecturers, int maxSeats, DateTime lastTimetoRegister, AcademicLevel requiredToAttend, AcademicLevel requiredToTeach)
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
        public bool AddAttendees(List<Person> p, bool isAdmin)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i] is Student)
                {
                    if (AddStudent(p[i], isAdmin) == false)
                        return false;
                }
                else if (p is Lecturer)
                {
                    if (AddLecturer(p[i], isAdmin) == false)
                        return false;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        private bool AddLecturer(Person p, bool isAdmin)
        {
            if (DateTime.Now < lastDayToRegister)
            {
                if (lecturers.Count < maxLecturers || isAdmin)
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

            return true;
        }

        private bool AddStudent(Person p, bool isAdmin)
        {
            if (DateTime.Now < lastDayToRegister || isAdmin)
            {
                if (students.Count < maxStudents)
                {
                    if ((int)p.Level >= (int)this.academicLevelRequiredToAttend)
                    {
                        students.Add(p as Student);
                    }
                }
                else if (studentsWaitList.Count < maxStudentsWaitList)
                {
                    if ((int)p.Level >= (int)this.academicLevelRequiredToAttend)
                    {
                        studentsWaitList.Add(p as Student);
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

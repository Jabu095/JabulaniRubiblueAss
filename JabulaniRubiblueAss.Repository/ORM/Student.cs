using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.ORM
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}

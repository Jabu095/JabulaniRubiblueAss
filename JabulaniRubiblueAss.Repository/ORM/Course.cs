using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.ORM
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}

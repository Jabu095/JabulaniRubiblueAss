using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JabulaniRubiblueAss.Helper.StudentCourse
{
    public class StudentCourseViewModel
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string CourseName { get; set; }
    }
}

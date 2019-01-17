using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JabulaniRubiblueAss.Helper.Course
{
    public class CourseViewModel
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}

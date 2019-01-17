using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JabulaniRubiblueAss.Helper.Student
{
    public class StudentViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }
    }
}

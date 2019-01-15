using JabulaniRubiblueAss.Helper.Student;
using JabulaniRubiblueAss.Repository.ORM;
using JabulaniRubiblueAss.Repository.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Service.Student
{
    public class StudentService : GenericService<Repository.ORM.Student>, IStudentService
    {
        private readonly IStudentRepostory StudentRepostory;
        public StudentService(IStudentRepostory studentRepostory):base(studentRepostory)
        {
            StudentRepostory = studentRepostory;
        }

        public async Task<int> GetNumberOfCourse(int StudentId)
        {
            var student = await StudentRepostory.GetStudentRelatedCoureses(StudentId);
            return student.StudentCourses.Count;
        }
    }
}

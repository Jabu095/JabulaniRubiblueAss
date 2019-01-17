using JabulaniRubiblueAss.Helper.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Service.Student
{
    public interface IStudentService : IGenericService<Repository.ORM.Student>
    {
        Task<int> GetNumberOfCourse(int StudentId);
        Task<Repository.ORM.Student> GetStudentCourseByStudentId(int StudentId);
    }
}

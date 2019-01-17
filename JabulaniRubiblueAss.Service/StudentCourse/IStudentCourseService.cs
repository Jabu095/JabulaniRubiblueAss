using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Service.StudentCourse
{
    public interface IStudentCourseService : IGenericService<Repository.ORM.StudentCourse>
    {
        Task<IList<Repository.ORM.StudentCourse>> GetAllStudentCourses();
        Task<Repository.ORM.StudentCourse> GetStudentByCourseId(int courseId);
    }
}

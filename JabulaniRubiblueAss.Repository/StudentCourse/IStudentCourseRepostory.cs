using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Repository.StudentCourse
{
    public interface IStudentCourseRepostory : IGenericRepository<ORM.StudentCourse>
    {
        Task<IList<ORM.StudentCourse>> GetAllStudentCourses();
        Task<ORM.StudentCourse> GetStudentByCourseId(int courseId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JabulaniRubiblueAss.Repository.ORM;

namespace JabulaniRubiblueAss.Service.StudentCourse
{
    public class StudentCourseService : GenericService<Repository.ORM.StudentCourse>, IStudentCourseService
    {
        private readonly Repository.StudentCourse.IStudentCourseRepostory StudentCourseRepostory;
        public StudentCourseService(Repository.StudentCourse.IStudentCourseRepostory studentCourseRepostory):base(studentCourseRepostory)
        {
            StudentCourseRepostory = studentCourseRepostory;
        }

        public async Task<IList<Repository.ORM.StudentCourse>> GetAllStudentCourses()
        {
            return await StudentCourseRepostory.GetAllStudentCourses();
        }

        public async Task<Repository.ORM.StudentCourse> GetStudentByCourseId(int courseId)
        {
            return await StudentCourseRepostory.GetStudentByCourseId(courseId);
        }
    }
}

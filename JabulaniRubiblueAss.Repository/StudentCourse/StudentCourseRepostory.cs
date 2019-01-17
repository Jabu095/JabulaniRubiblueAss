using JabulaniRubiblueAss.Repository.Data;
using JabulaniRubiblueAss.Repository.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Repository.StudentCourse
{
    public class StudentCourseRepostory : GenericRepository<ORM.StudentCourse>, IStudentCourseRepostory
    {
        public StudentCourseRepostory(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IList<ORM.StudentCourse>> GetAllStudentCourses()
        {
            return await DbContext.StudentCourse.Include(s => s.Course).Include(s => s.Student).ToListAsync();
        }

        public async Task<ORM.StudentCourse> GetStudentByCourseId(int courseId)
        {
            return await DbContext.StudentCourse.Include(x => x.Course).Include(x => x.Student).FirstOrDefaultAsync(m => m.CourseId.Equals(courseId));
        }
    }
}

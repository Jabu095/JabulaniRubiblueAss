using JabulaniRubiblueAss.Repository.Data;
using JabulaniRubiblueAss.Repository.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Repository.Student
{
    public class StudentRepostory : GenericRepository<ORM.Student>, IStudentRepostory
    {
        public StudentRepostory(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<ORM.Student> GetStudentRelatedCoureses(int StudentId)
        {
            return await DbContext.Students.Include(x => x.StudentCourses).SingleOrDefaultAsync(k => k.StudentId.Equals(StudentId));
        }
    }
}

using JabulaniRubiblueAss.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.StudentCourse
{
    public class StudentCourseRepostory : GenericRepository<ORM.StudentCourse>, IStudentCourseRepostory
    {
        public StudentCourseRepostory(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}

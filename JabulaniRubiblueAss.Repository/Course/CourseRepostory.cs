using JabulaniRubiblueAss.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.Course
{
    public class CourseRepostory:GenericRepository<ORM.Course>, ICourseRepostory
    {
        public CourseRepostory(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}

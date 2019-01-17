using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JabulaniRubiblueAss.Repository.ORM;
using Microsoft.EntityFrameworkCore;

namespace JabulaniRubiblueAss.Service.Course
{
    public class CourseService : GenericService<Repository.ORM.Course>, ICourseService
    {
        public CourseService(Repository.Course.ICourseRepostory courseRepostory):base(courseRepostory)
        {

        }

        public async Task<Repository.ORM.Course> GetCourseByName(string courseName)
        {
            return await EntityRepository
                     .Query()
                     .Where(x => x.CourseName.Equals(courseName, StringComparison.OrdinalIgnoreCase))
                     .FirstOrDefaultAsync();
                            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Service.Course
{
    public interface ICourseService : IGenericService<Repository.ORM.Course>
    {
        Task<Repository.ORM.Course> GetCourseByName(string courseName);
    }
}

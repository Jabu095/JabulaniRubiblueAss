using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniRubiblueAss.Repository.Student
{
    public interface IStudentRepostory: IGenericRepository<ORM.Student>
    {
        Task<Repository.ORM.Student> GetStudentRelatedCoureses(int StudentId);
    }
}

using JabulaniRubiblueAss.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository
{
    public class RepositoyModule
    {
        public static void Register(IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<Student.IStudentRepostory, Student.StudentRepostory>();
            services.AddTransient<Course.ICourseRepostory, Course.CourseRepostory>();
            services.AddTransient<StudentCourse.IStudentCourseRepostory, StudentCourse.StudentCourseRepostory>();
        }
    }
}

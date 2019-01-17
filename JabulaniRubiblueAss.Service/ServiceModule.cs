using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Service
{
    public class ServiceModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<Student.IStudentService, Student.StudentService>();
            services.AddTransient<Course.ICourseService, Course.CourseService>();
            services.AddTransient<StudentCourse.IStudentCourseService, StudentCourse.StudentCourseService>();
        }
    }
}

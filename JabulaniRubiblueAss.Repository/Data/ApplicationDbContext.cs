using JabulaniRubiblueAss.Repository.ORM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JabulaniRubiblueAss.Repository.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ORM.StudentCourse>()
                .HasKey(x => new { x.CourseId, x.StudentId });

            builder.Entity<ORM.StudentCourse>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentCourses)
                .HasForeignKey(x => x.StudentId);

            builder.Entity<ORM.StudentCourse>()
               .HasOne(x => x.Course)
               .WithMany(x => x.StudentCourses)
               .HasForeignKey(x => x.CourseId);

            builder.Entity<ORM.Student>()
                .HasIndex(x => x.IDNumber)
                .IsUnique(true);

            builder.Entity<ORM.Course>()
                .HasIndex(x => x.CourseName)
                .IsUnique(true);


            builder.Entity<ORM.Student>()
                .HasData(
                new ORM.Student
                {
                   StudentId = 1,
                    EmailAddress = "Jaybeedzivas@gmail.com",
                    FirstName = "Jabulani",
                    IDNumber = "4514512761256",
                    Surname = "Madzivadondo"
                });

            builder.Entity<ORM.Course>()
               .HasData(
               new ORM.Course
               {
                   CourseId = 1,
                   CourseName = "Chemistry",
                   StartDate = new DateTime(2018,1,14),
                   EndDate = new DateTime(2018,1,25)
               },
               new ORM.Course
               {
                   CourseId = 2,
                   CourseName = "Computer Science",
                   StartDate = new DateTime(2018, 1, 15),
                   EndDate = new DateTime(2018, 1, 27)
               });
        }

        public DbSet<ORM.Student> Students { get; set; }
        public DbSet<ORM.Course> Courses { get; set; }
        public DbSet<ORM.StudentCourse> StudentCourse { get; set; }
    }
}

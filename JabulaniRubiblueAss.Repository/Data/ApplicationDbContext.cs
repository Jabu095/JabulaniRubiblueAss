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

        }

        public DbSet<ORM.Student> Students { get; set; }
        public DbSet<ORM.Course> Courses { get; set; }
        public DbSet<ORM.StudentCourse> StudentCourse { get; set; }
    }
}

﻿// <auto-generated />
using System;
using JabulaniRubiblueAss.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JabulaniRubiblueAss.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190116125508_uniquecoursename")]
    partial class uniquecoursename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JabulaniRubiblueAss.Repository.ORM.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseName")
                        .IsUnique()
                        .HasFilter("[CourseName] IS NOT NULL");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("JabulaniRubiblueAss.Repository.ORM.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FirstName");

                    b.Property<string>("IDNumber");

                    b.Property<string>("Surname");

                    b.HasKey("StudentId");

                    b.HasIndex("IDNumber")
                        .IsUnique()
                        .HasFilter("[IDNumber] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("JabulaniRubiblueAss.Repository.ORM.StudentCourse", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("JabulaniRubiblueAss.Repository.ORM.StudentCourse", b =>
                {
                    b.HasOne("JabulaniRubiblueAss.Repository.ORM.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JabulaniRubiblueAss.Repository.ORM.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

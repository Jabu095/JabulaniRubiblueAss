using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JabulaniRubiblueAss.Repository.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "EndDate", "StartDate" },
                values: new object[] { 1, "Chemistry", new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "EndDate", "StartDate" },
                values: new object[] { 2, "Computer Science", new DateTime(2018, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "EmailAddress", "FirstName", "IDNumber", "Surname" },
                values: new object[] { 1, "Jaybeedzivas@gmail.com", "Jabulani", "4514512761256", "Madzivadondo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);
        }
    }
}

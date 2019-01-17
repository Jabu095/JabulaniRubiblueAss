using Microsoft.EntityFrameworkCore.Migrations;

namespace JabulaniRubiblueAss.Repository.Migrations
{
    public partial class uniquecoursename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseName",
                table: "Courses",
                column: "CourseName",
                unique: true,
                filter: "[CourseName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseName",
                table: "Courses");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

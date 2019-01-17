using Microsoft.EntityFrameworkCore.Migrations;

namespace JabulaniRubiblueAss.Repository.Migrations
{
    public partial class uniquekeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDNumber",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_IDNumber",
                table: "Students",
                column: "IDNumber",
                unique: true,
                filter: "[IDNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Students_IDNumber",
                table: "Students");

            migrationBuilder.AlterColumn<string>(
                name: "IDNumber",
                table: "Students",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

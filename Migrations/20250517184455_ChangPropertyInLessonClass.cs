using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oman_Driving_School_System.Migrations
{
    /// <inheritdoc />
    public partial class ChangPropertyInLessonClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Lessons",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "Lessons",
                newName: "Note");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Lessons",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Lessons",
                newName: "note");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class updateschemacourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "Common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "Common",
                newName: "Courses");
        }
    }
}

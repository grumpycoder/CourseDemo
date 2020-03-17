using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class updateschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tags",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grades",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "DeliveryTypes",
                newName: "DeliveryTypes",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "CourseTypes",
                newName: "CourseTypes",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "CourseLevels",
                newName: "CourseLevels",
                newSchema: "Common");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Tags",
                schema: "Common",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "Grades",
                schema: "Common",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "DeliveryTypes",
                schema: "Common",
                newName: "DeliveryTypes");

            migrationBuilder.RenameTable(
                name: "CourseTypes",
                schema: "Common",
                newName: "CourseTypes");

            migrationBuilder.RenameTable(
                name: "CourseLevels",
                schema: "Common",
                newName: "CourseLevels");
        }
    }
}

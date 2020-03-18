using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class programassignmentsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                schema: "CareerTech",
                table: "ProgramCourses");

            migrationBuilder.AddColumn<int>(
                name: "BeginYear",
                schema: "CareerTech",
                table: "ProgramCourses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                schema: "CareerTech",
                table: "ProgramCourses",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                schema: "CareerTech",
                table: "ProgramCourses",
                column: "CourseId",
                principalSchema: "Common",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                schema: "CareerTech",
                table: "ProgramCourses");

            migrationBuilder.DropColumn(
                name: "BeginYear",
                schema: "CareerTech",
                table: "ProgramCourses");

            migrationBuilder.DropColumn(
                name: "EndYear",
                schema: "CareerTech",
                table: "ProgramCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramCourses_Courses_CourseId",
                schema: "CareerTech",
                table: "ProgramCourses",
                column: "CourseId",
                principalSchema: "Common",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

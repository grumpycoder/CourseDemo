using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class clusters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BeginYear",
                schema: "CareerTech",
                table: "ProgramCourses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Clusters",
                schema: "CareerTech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClusterCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BeginYear = table.Column<int>(nullable: true),
                    EndYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clusters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clusters",
                schema: "CareerTech");

            migrationBuilder.AlterColumn<int>(
                name: "BeginYear",
                schema: "CareerTech",
                table: "ProgramCourses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

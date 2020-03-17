using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class programs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "CareerTech");

            migrationBuilder.CreateTable(
                name: "Programs",
                schema: "CareerTech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BeginYear = table.Column<int>(nullable: true),
                    EndYear = table.Column<int>(nullable: true),
                    TraditionalForMales = table.Column<bool>(nullable: true),
                    TraditionalForFemales = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programs",
                schema: "CareerTech");
        }
    }
}

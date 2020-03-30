using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseDemo.Data.Migrations
{
    public partial class credentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                schema: "CareerTech",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CredentialCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BeginYear = table.Column<int>(nullable: true),
                    EndYear = table.Column<int>(nullable: true),
                    IsReimbursable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials",
                schema: "CareerTech");
        }
    }
}

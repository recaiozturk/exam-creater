using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamCreateDemo.Web.Migrations
{
    public partial class UpdatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExamCreatedDate",
                table: "Exams",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamCreatedDate",
                table: "Exams");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamCreateDemo.Web.Migrations
{
    public partial class ExamTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExamArticleHeader = table.Column<string>(type: "TEXT", nullable: true),
                    ExamArticleContent = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOne = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOneAnswerA = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOneAnswerB = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOneAnswerC = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOneAnswerD = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionOneCorrectAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwo = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwoAnswerA = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwoAnswerB = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwoAnswerC = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwoAnswerD = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionTwoCorrectAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThree = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThreeAnswerA = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThreeAnswerB = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThreeAnswerC = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThreeAnswerD = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionThreeCorrectAnswer = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFour = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFourAnswerA = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFourAnswerB = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFourAnswerC = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFourAnswerD = table.Column<string>(type: "TEXT", nullable: true),
                    QuestionFourCorrectAnswer = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTitles.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GradeCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTitles_Titles_TitleId",
                table: "EmployeeTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTitles_Titles_TitleId",
                table: "EmployeeTitles",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("ALTER TABLE Titles ADD CONSTRAINT CK_Title_Grade CHECK (Grade >= 1 AND Grade <= 15)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE Titles DROP CONSTRAINT CK_Title_Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTitles_Titles_TitleId",
                table: "EmployeeTitles");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTitles_Titles_TitleId",
                table: "EmployeeTitles",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

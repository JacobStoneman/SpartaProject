using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaProjectModel.Migrations
{
    public partial class fixed_spelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Products",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Products",
                newName: "url");
        }
    }
}

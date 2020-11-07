using Microsoft.EntityFrameworkCore.Migrations;

namespace SpartaProjectModel.Migrations
{
    public partial class added_url_to_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "Products");
        }
    }
}

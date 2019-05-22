using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations.Web2019ReVamp
{
    public partial class photoName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Reports",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Reports");
        }
    }
}

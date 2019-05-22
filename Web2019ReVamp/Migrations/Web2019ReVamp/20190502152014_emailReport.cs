using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations.Web2019ReVamp
{
    public partial class emailReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Reports",
                newName: "userEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Reports",
                newName: "userName");
        }
    }
}

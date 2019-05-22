using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations.Web2019ReVamp
{
    public partial class UpvotesFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvId",
                table: "Upvotes");

            migrationBuilder.RenameColumn(
                name: "UpvotesCounter",
                table: "Upvotes",
                newName: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportId",
                table: "Upvotes",
                newName: "UpvotesCounter");

            migrationBuilder.AddColumn<int>(
                name: "InvId",
                table: "Upvotes",
                nullable: false,
                defaultValue: 0);
        }
    }
}

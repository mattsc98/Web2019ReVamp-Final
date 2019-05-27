using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations
{
    public partial class inv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c43590e-8e99-49ae-b43f-46e0e023ba7d", "90622b8b-15d0-4cdd-9338-088ea45bbad2", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8c43590e-8e99-49ae-b43f-46e0e023ba7d", "90622b8b-15d0-4cdd-9338-088ea45bbad2" });
        }
    }
}

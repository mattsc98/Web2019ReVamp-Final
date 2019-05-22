using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    userEmail = table.Column<string>(nullable: true),
                    InvId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    RepDate = table.Column<DateTime>(nullable: false),
                    HazardDateTime = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    HazardType = table.Column<string>(nullable: true),
                    RepDescription = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PhotoName = table.Column<string>(nullable: true),
                    Upvotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersViewer",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TotalReports = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersViewer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "UsersViewer");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers");
        }
    }
}

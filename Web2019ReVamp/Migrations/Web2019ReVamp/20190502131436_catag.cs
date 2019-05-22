using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2019ReVamp.Migrations.Web2019ReVamp
{
    public partial class catag : Migration
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
                    userName = table.Column<string>(nullable: true),
                    InvId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    RepDate = table.Column<DateTime>(nullable: false),
                    HazardDateTime = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    HazardType = table.Column<string>(nullable: true),
                    RepDescription = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Upvotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}

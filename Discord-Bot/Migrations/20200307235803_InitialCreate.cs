using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Discord_Bot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guild",
                columns: table => new
                {
                    id = table.Column<decimal>(maxLength: 18, nullable: false),
                    announcementChannel = table.Column<decimal>(maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<decimal>(maxLength: 18, nullable: false),
                    birthday = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guild");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}

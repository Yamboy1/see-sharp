using Microsoft.EntityFrameworkCore.Migrations;

namespace Discord_Bot.Migrations
{
    public partial class Casing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_guild_GuildId",
                table: "UserGuild");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_user_UserId",
                table: "UserGuild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_guild",
                table: "guild");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "guild",
                newName: "Guild");

            migrationBuilder.RenameColumn(
                name: "birthday",
                table: "User",
                newName: "Birthday");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "announcementChannel",
                table: "Guild",
                newName: "AnnouncementChannel");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Guild",
                newName: "GuildId");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserId",
                table: "UserGuild",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "GuildId",
                table: "UserGuild",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserId",
                table: "User",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "AnnouncementChannel",
                table: "Guild",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<decimal>(
                name: "GuildId",
                table: "Guild",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 18);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guild",
                table: "Guild",
                column: "GuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_Guild_GuildId",
                table: "UserGuild",
                column: "GuildId",
                principalTable: "Guild",
                principalColumn: "GuildId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_User_UserId",
                table: "UserGuild",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_Guild_GuildId",
                table: "UserGuild");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuild_User_UserId",
                table: "UserGuild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guild",
                table: "Guild");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Guild",
                newName: "guild");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "user",
                newName: "birthday");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "AnnouncementChannel",
                table: "guild",
                newName: "announcementChannel");

            migrationBuilder.RenameColumn(
                name: "GuildId",
                table: "guild",
                newName: "id");

            migrationBuilder.AlterColumn<decimal>(
                name: "UserId",
                table: "UserGuild",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "GuildId",
                table: "UserGuild",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "id",
                table: "user",
                type: "numeric",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "announcementChannel",
                table: "guild",
                type: "numeric",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "id",
                table: "guild",
                type: "numeric",
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guild",
                table: "guild",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_guild_GuildId",
                table: "UserGuild",
                column: "GuildId",
                principalTable: "guild",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuild_user_UserId",
                table: "UserGuild",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

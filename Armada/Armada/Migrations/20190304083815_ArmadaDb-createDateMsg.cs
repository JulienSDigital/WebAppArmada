using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Armada.Migrations
{
    public partial class ArmadaDbcreateDateMsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageDateCreate",
                table: "Messages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MessageDateCreate",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}

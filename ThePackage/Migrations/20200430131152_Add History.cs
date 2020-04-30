using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePackage.Migrations
{
    public partial class AddHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInsert",
                table: "Staff",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Staff",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Client",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateInsert",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Staff");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateUpdate",
                table: "Client",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}

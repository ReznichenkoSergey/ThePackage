using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePackage.Migrations
{
    public partial class PackageActionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInsert",
                table: "Point",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Point",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Package",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Package",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateInsert",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Package");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateInsert",
                table: "Package",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));
        }
    }
}

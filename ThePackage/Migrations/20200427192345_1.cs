using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThePackage.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateInsert = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    SumDeliver = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    SumPayed = table.Column<decimal>(type: "money", nullable: false, defaultValue: 0m),
                    StatusId = table.Column<int>(nullable: false),
                    PointSourceId = table.Column<int>(nullable: true),
                    PointDestinationId = table.Column<int>(nullable: true),
                    ClientSenderId = table.Column<int>(nullable: true),
                    ClientReceiverId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Client_ClientReceiverId",
                        column: x => x.ClientReceiverId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Client_ClientSenderId",
                        column: x => x.ClientSenderId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Point_PointDestinationId",
                        column: x => x.PointDestinationId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Point_PointSourceId",
                        column: x => x.PointSourceId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Units_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UnitsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffToPoint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StaffId = table.Column<int>(nullable: false),
                    PointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffToPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffToPoint_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffToPoint_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PackageType",
                columns: new[] { "Id", "Comment", "Name" },
                values: new object[,]
                {
                    { 1, null, "Техника" },
                    { 2, null, "Канцелярия" },
                    { 3, null, "Стекло" },
                    { 4, null, "Авто. детали" },
                    { 5, null, "Одежда" },
                    { 6, null, "Мебель" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[,]
                {
                    { 1, "К отправке", 0 },
                    { 2, "Отправлена", 0 },
                    { 3, "Получена на склад", 0 },
                    { 4, "Возврат", 0 },
                    { 5, "Выдана", 0 },
                    { 10, "Менеджер", 1 },
                    { 11, "Кассир", 1 },
                    { 12, "Кладовщик", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_ClientReceiverId",
                table: "Package",
                column: "ClientReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ClientSenderId",
                table: "Package",
                column: "ClientSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_PointDestinationId",
                table: "Package",
                column: "PointDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_PointSourceId",
                table: "Package",
                column: "PointSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_StatusId",
                table: "Package",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UnitsId",
                table: "Staff",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffToPoint_PointId",
                table: "StaffToPoint",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffToPoint_StaffId",
                table: "StaffToPoint",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "PackageType");

            migrationBuilder.DropTable(
                name: "StaffToPoint");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}

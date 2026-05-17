using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeraRakshak.Migrations
{
    public partial class AddContactsAndCallLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImeiNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallerImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallLogs");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}

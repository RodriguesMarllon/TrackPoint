using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingWorkLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity = table.Column<long>(type: "bigint", nullable: false),
                    Employee = table.Column<long>(type: "bigint", nullable: false),
                    EntryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Break = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    WorkHours = table.Column<float>(type: "real", nullable: false),
                    DayType = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expenses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValidationResponsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkLogs_Activity_Activity",
                        column: x => x.Activity,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkLogs_Employees_Employee",
                        column: x => x.Employee,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkLogs_Activity",
                table: "WorkLogs",
                column: "Activity");

            migrationBuilder.CreateIndex(
                name: "IX_WorkLogs_Employee",
                table: "WorkLogs",
                column: "Employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkLogs");

            migrationBuilder.DropTable(
                name: "Activity");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixActivityForeingKeyOnWorkLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Activity_Activity",
                table: "WorkLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Employees_Employee",
                table: "WorkLogs");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "WorkLogs",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Activity",
                table: "WorkLogs",
                newName: "ActivityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_Employee",
                table: "WorkLogs",
                newName: "IX_WorkLogs_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_Activity",
                table: "WorkLogs",
                newName: "IX_WorkLogs_ActivityId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activity",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "External",
                table: "Activity",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Activity",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Activity_ActivityId",
                table: "WorkLogs",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Employees_EmployeeId",
                table: "WorkLogs",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Activity_ActivityId",
                table: "WorkLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkLogs_Employees_EmployeeId",
                table: "WorkLogs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "External",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Activity");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "WorkLogs",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "ActivityId",
                table: "WorkLogs",
                newName: "Activity");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_EmployeeId",
                table: "WorkLogs",
                newName: "IX_WorkLogs_Employee");

            migrationBuilder.RenameIndex(
                name: "IX_WorkLogs_ActivityId",
                table: "WorkLogs",
                newName: "IX_WorkLogs_Activity");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Activity_Activity",
                table: "WorkLogs",
                column: "Activity",
                principalTable: "Activity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkLogs_Employees_Employee",
                table: "WorkLogs",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

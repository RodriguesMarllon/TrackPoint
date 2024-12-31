using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Signature = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    DateInsertUpdate = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

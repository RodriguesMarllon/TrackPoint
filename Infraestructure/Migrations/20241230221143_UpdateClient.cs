using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClientId1",
                table: "Projects",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Clients",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "Clients",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId1",
                table: "Projects",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Clients_ClientId1",
                table: "Projects",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Clients_ClientId1",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Clients");
        }
    }
}

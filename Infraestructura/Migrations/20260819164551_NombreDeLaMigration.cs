using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteResponsablePagoId",
                table: "Clientes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResponsablePagoId",
                table: "Clientes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClienteResponsablePagoId",
                table: "Clientes",
                column: "ClienteResponsablePagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_ClienteResponsablePagoId",
                table: "Clientes",
                column: "ClienteResponsablePagoId",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ResponsablePagoId",
                table: "Clientes");
        }
    }
}

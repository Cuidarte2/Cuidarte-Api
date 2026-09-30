using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class arregloResponsablepago : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ResponsablePagoId",
                table: "Clientes",
                column: "ResponsablePagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Clientes_ResponsablePagoId",
                table: "Clientes",
                column: "ResponsablePagoId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_ResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ResponsablePagoId",
                table: "Clientes");
        }
    }
}

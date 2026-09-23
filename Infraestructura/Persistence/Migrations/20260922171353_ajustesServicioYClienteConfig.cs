using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ajustesServicioYClienteConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Clientes_ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteId1",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ClienteResponsablePagoId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteId1",
                table: "Servicios",
                newName: "ClienteExtraId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Servicios",
                newName: "ClienteDisponibleId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_ClienteId1",
                table: "Servicios",
                newName: "IX_Servicios_ClienteExtraId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_ClienteId",
                table: "Servicios",
                newName: "IX_Servicios_ClienteDisponibleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Clientes_ClienteDisponibleId",
                table: "Servicios",
                column: "ClienteDisponibleId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Clientes_ClienteExtraId",
                table: "Servicios",
                column: "ClienteExtraId",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteDisponibleId",
                table: "Servicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_Clientes_ClienteExtraId",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ResponsablePagoId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteExtraId",
                table: "Servicios",
                newName: "ClienteId1");

            migrationBuilder.RenameColumn(
                name: "ClienteDisponibleId",
                table: "Servicios",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_ClienteExtraId",
                table: "Servicios",
                newName: "IX_Servicios_ClienteId1");

            migrationBuilder.RenameIndex(
                name: "IX_Servicios_ClienteDisponibleId",
                table: "Servicios",
                newName: "IX_Servicios_ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "ClienteResponsablePagoId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Clientes_ClienteId",
                table: "Servicios",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_Clientes_ClienteId1",
                table: "Servicios",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class arregloResponsablepago2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ResponsablePagoId",
                table: "Clientes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Cliente_NoAutoResponsable",
                table: "Clientes",
                sql: "\"ResponsablePagoId\" IS NULL OR \"ResponsablePagoId\" <> \"Id\"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Cliente_NoAutoResponsable",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsablePagoId",
                table: "Clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Malvin_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEntradaDetalleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "EntradaDetalles",
                newName: "NombreProducto");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EntradaDetalles",
                newName: "EntradaDetalleId");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    PesoUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.RenameColumn(
                name: "NombreProducto",
                table: "EntradaDetalles",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "EntradaDetalleId",
                table: "EntradaDetalles",
                newName: "Id");
        }
    }
}

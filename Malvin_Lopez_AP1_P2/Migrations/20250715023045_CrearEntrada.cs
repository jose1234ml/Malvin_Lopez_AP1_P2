using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Malvin_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class CrearEntrada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalles_Entradas_EntradaId",
                table: "EntradaDetalles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradaDetalles",
                table: "EntradaDetalles");

            migrationBuilder.RenameTable(
                name: "Entradas",
                newName: "Entrada");

            migrationBuilder.RenameTable(
                name: "EntradaDetalles",
                newName: "EntradaDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_EntradaDetalles_EntradaId",
                table: "EntradaDetalle",
                newName: "IX_EntradaDetalle_EntradaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrada",
                table: "Entrada",
                column: "EntradaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradaDetalle",
                table: "EntradaDetalle",
                column: "EntradaDetalleId");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Peso = table.Column<decimal>(type: "numeric", nullable: false),
                    Existencia = table.Column<decimal>(type: "numeric", nullable: false),
                    EsCompuesto = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Descripcion", "EsCompuesto", "Existencia", "Peso" },
                values: new object[,]
                {
                    { 1, "Maní", false, 100m, 10.00m },
                    { 2, "Pistachos", false, 100m, 5.00m },
                    { 3, "Almendras", false, 100m, 20.00m },
                    { 4, "Frutos Mixtos 200gr", true, 0m, 200.00m },
                    { 5, "Frutos Mixtos 400gr", true, 0m, 400.00m },
                    { 6, "Frutos Mixtos 600gr", true, 0m, 600.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaDetalle_ProductoId",
                table: "EntradaDetalle",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Entrada_EntradaId",
                table: "EntradaDetalle",
                column: "EntradaId",
                principalTable: "Entrada",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalle_Producto_ProductoId",
                table: "EntradaDetalle",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Entrada_EntradaId",
                table: "EntradaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_EntradaDetalle_Producto_ProductoId",
                table: "EntradaDetalle");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradaDetalle",
                table: "EntradaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_EntradaDetalle_ProductoId",
                table: "EntradaDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrada",
                table: "Entrada");

            migrationBuilder.RenameTable(
                name: "EntradaDetalle",
                newName: "EntradaDetalles");

            migrationBuilder.RenameTable(
                name: "Entrada",
                newName: "Entradas");

            migrationBuilder.RenameIndex(
                name: "IX_EntradaDetalle_EntradaId",
                table: "EntradaDetalles",
                newName: "IX_EntradaDetalles_EntradaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradaDetalles",
                table: "EntradaDetalles",
                column: "EntradaDetalleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas",
                column: "EntradaId");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    EsCompuesto = table.Column<bool>(type: "boolean", nullable: false),
                    Existencia = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<int>(type: "integer", nullable: false),
                    PesoUnitario = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Descripcion", "EsCompuesto", "Existencia", "Peso", "PesoUnitario" },
                values: new object[,]
                {
                    { 1, "Maní", false, 100, 0, 0m },
                    { 2, "Pistachos", false, 100, 0, 0m },
                    { 3, "Almendras", false, 100, 0, 0m },
                    { 4, "Frutos Mixtos 200gr", true, 0, 200, 0m },
                    { 5, "Frutos Mixtos 400gr", true, 0, 400, 0m },
                    { 6, "Frutos Mixtos 600gr", true, 0, 600, 0m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaDetalles_Entradas_EntradaId",
                table: "EntradaDetalles",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

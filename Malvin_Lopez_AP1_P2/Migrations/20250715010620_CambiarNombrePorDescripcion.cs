using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Malvin_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombrePorDescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Productos",
                newName: "Descripcion");

            migrationBuilder.AddColumn<bool>(
                name: "EsCompuesto",
                table: "Productos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Existencia",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Productos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "EsCompuesto",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Existencia",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Productos",
                newName: "Nombre");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Malvin_Lopez_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class peso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PesoTotal",
                table: "Entradas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PesoTotal",
                table: "Entradas");
        }
    }
}

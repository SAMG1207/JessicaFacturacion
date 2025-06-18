using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JessicaFacturacion.Migrations
{
    /// <inheritdoc />
    public partial class mejoraTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "TipoFacturaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "TipoFacturaciones");
        }
    }
}

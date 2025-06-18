using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JessicaFacturacion.Migrations
{
    /// <inheritdoc />
    public partial class Initiad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URLto = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    ResponseCode = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorDetail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logger", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logger");
        }
    }
}

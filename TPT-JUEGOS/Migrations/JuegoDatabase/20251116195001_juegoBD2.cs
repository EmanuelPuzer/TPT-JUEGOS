using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPT_JUEGOS.Migrations.JuegoDatabase
{
    /// <inheritdoc />
    public partial class juegoBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CODIGO_JUEGO",
                table: "Juegos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CODIGO_JUEGO",
                table: "Juegos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

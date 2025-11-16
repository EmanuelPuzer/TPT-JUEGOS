using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPT_JUEGOS.Migrations.JuegoDatabase
{
    /// <inheritdoc />
    public partial class juegoBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    Id_JUEGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_JUEGO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JUEGO_ACTIVO = table.Column<int>(type: "int", nullable: false),
                    CODIGO_JUEGO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.Id_JUEGO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juegos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPT_JUEGOS.Migrations.JuegoDatabase
{
    /// <inheritdoc />
    public partial class AgregandoCatalogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "CatalogoJuegos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoJuegos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoJuegos");

            migrationBuilder.DropColumn(
                name: "NOMBRE_IMAGEN",
                table: "Juegos");
        }
    }
}

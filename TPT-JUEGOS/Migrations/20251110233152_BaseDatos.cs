using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPT_JUEGOS.Migrations
{
    /// <inheritdoc />
    public partial class BaseDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_PERSONA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EDAD_USUARIO = table.Column<int>(type: "int", nullable: false),
                    NOMBRE_USUARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CORREO_USUARIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTRASENA_USUARIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}

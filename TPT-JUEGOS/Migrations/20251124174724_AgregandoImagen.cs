using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPT_JUEGOS.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
        name: "NOMBRE_IMAGEN",
        table: "Juegos",
        type: "nvarchar(max)",
        nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TorresJ_Liga_Pro_de_Ecuador.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumPartidosJugados = table.Column<int>(type: "int", nullable: false),
                    NumPartidosGanados = table.Column<int>(type: "int", nullable: false),
                    NumPartidosPerdidos = table.Column<int>(type: "int", nullable: false),
                    NumPartidosEmpatados = table.Column<int>(type: "int", nullable: false),
                    Puntos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                });

            migrationBuilder.CreateTable(
                name: "Jugador",
                columns: table => new
                {
                    IdNombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dorsal = table.Column<int>(type: "int", nullable: false),
                    goles = table.Column<int>(type: "int", nullable: false),
                    asistencias = table.Column<int>(type: "int", nullable: false),
                    sueldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdEquipoActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugador", x => x.IdNombre);
                    table.ForeignKey(
                        name: "FK_Jugador_Equipo_IdEquipoActual",
                        column: x => x.IdEquipoActual,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugador_IdEquipoActual",
                table: "Jugador",
                column: "IdEquipoActual");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Equipo");
        }
    }
}

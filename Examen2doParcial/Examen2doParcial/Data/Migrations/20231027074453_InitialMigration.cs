using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Examen2doParcial.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "discos",
                columns: table => new
                {
                    Id_Disco = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    autor = table.Column<string>(type: "text", nullable: false),
                    year = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discos", x => x.Id_Disco);
                });

            migrationBuilder.CreateTable(
                name: "musicas",
                columns: table => new
                {
                    Id_Musica = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    Genero = table.Column<string>(type: "text", nullable: false),
                    NumeroReproducciones = table.Column<int>(type: "integer", nullable: false),
                    Id_Disco = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musicas", x => x.Id_Musica);
                    table.ForeignKey(
                        name: "FK_musicas_discos_Id_Disco",
                        column: x => x.Id_Disco,
                        principalTable: "discos",
                        principalColumn: "Id_Disco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_musicas_Id_Disco",
                table: "musicas",
                column: "Id_Disco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "musicas");

            migrationBuilder.DropTable(
                name: "discos");
        }
    }
}

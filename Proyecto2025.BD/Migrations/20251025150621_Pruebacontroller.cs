using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudioJuridico.BD.Migrations
{
    /// <inheritdoc />
    public partial class Pruebacontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TasaJusticia_Aportes = table.Column<bool>(type: "bit", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasosPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    CasoId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasosPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CasosPersona_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "Casos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CasosPersona_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documentacions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArchivoUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    CasoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentacionId = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentacions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentacions_Casos_CasoId",
                        column: x => x.CasoId,
                        principalTable: "Casos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documentacions_TipoDocumentos_TipoDocumentacionId",
                        column: x => x.TipoDocumentacionId,
                        principalTable: "TipoDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasosPersona_CasoId",
                table: "CasosPersona",
                column: "CasoId");

            migrationBuilder.CreateIndex(
                name: "IX_CasosPersona_PersonaId",
                table: "CasosPersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentacions_CasoId",
                table: "Documentacions",
                column: "CasoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentacions_TipoDocumentacionId",
                table: "Documentacions",
                column: "TipoDocumentacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasosPersona");

            migrationBuilder.DropTable(
                name: "Documentacions");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}

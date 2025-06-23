using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudioJuridico.BD.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ArchivoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NomPais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
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
                    DNI = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TasaJusticia_Aportes = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTestigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NomProvincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincias_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonasID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Personas_PersonasID",
                        column: x => x.PersonasID,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasPenals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantillaPenals = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasPenals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonasPenals_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NomLocalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinciaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaID",
                        column: x => x.ProvinciaID,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plantillas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Piso = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LocalidadID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilios_Localidades_LocalidadID",
                        column: x => x.LocalidadID,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantillasPenals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Delito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Juzgado = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EstadoCausa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Pruebas = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    RadiografiaExpediente = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    FechaDetencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InformeId = table.Column<int>(type: "int", nullable: false),
                    PlantillaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillasPenals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantillasPenals_Informes_InformeId",
                        column: x => x.InformeId,
                        principalTable: "Informes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantillasPenals_Plantillas_PlantillaId",
                        column: x => x.PlantillaId,
                        principalTable: "Plantillas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonasDomicilios",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    DomicilioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasDomicilios", x => new { x.PersonaID, x.DomicilioID });
                    table.ForeignKey(
                        name: "FK_PersonasDomicilios_Domicilios_DomicilioID",
                        column: x => x.DomicilioID,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonasDomicilios_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantillasPenalTienenTestigos",
                columns: table => new
                {
                    PlantillaPenalId = table.Column<int>(type: "int", nullable: false),
                    TestigoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillasPenalTienenTestigos", x => new { x.PlantillaPenalId, x.TestigoId });
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_PlantillasPenals_PlantillaPenalId",
                        column: x => x.PlantillaPenalId,
                        principalTable: "PlantillasPenals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Testigos_TestigoId",
                        column: x => x.TestigoId,
                        principalTable: "Testigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PersonasID",
                table: "Clientes",
                column: "PersonasID");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_LocalidadID",
                table: "Domicilios",
                column: "LocalidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaID",
                table: "Localidades",
                column: "ProvinciaID");

            migrationBuilder.CreateIndex(
                name: "Localidad_Codigo_UQ",
                table: "Localidades",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Pais_Codigo_UQ",
                table: "Paises",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDomicilios_DomicilioID",
                table: "PersonasDomicilios",
                column: "DomicilioID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasPenals_PersonaId",
                table: "PersonasPenals",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_ClienteId",
                table: "Plantillas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenals_InformeId",
                table: "PlantillasPenals",
                column: "InformeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenals_PlantillaId",
                table: "PlantillasPenals",
                column: "PlantillaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_TestigoId",
                table: "PlantillasPenalTienenTestigos",
                column: "TestigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaisID",
                table: "Provincias",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "Provincia_Codigo_UQ",
                table: "Provincias",
                column: "Codigo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonasDomicilios");

            migrationBuilder.DropTable(
                name: "PersonasPenals");

            migrationBuilder.DropTable(
                name: "PlantillasPenalTienenTestigos");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "PlantillasPenals");

            migrationBuilder.DropTable(
                name: "Testigos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}

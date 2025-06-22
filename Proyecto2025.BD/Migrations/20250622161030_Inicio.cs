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
                    idInformes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ArchivoUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.idInformes);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    idPaises = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NomPais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.idPaises);
                });

            migrationBuilder.CreateTable(
                name: "Testigos",
                columns: table => new
                {
                    idTestigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTestigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testigos", x => x.idTestigo);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    idProvincias = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NomProvincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.idProvincias);
                    table.ForeignKey(
                        name: "FK_Provincias_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    idLocalidades = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NomLocalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.idLocalidades);
                    table.ForeignKey(
                        name: "FK_Localidades_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    idDomicilios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    Calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Barrio = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Piso = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.idDomicilios);
                    table.ForeignKey(
                        name: "FK_Domicilios_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_Domicilios_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_Domicilios_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    idPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DNI = table.Column<int>(type: "int", maxLength: 45, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TasaJusticia_Aportes = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.idPersona);
                    table.ForeignKey(
                        name: "FK_Personas_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_Personas_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_Personas_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_Personas_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "PersonasPenal",
                columns: table => new
                {
                    idPersonaPenal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasPenal", x => x.idPersonaPenal);
                    table.ForeignKey(
                        name: "FK_PersonasPenal_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_PersonasPenal_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_PersonasPenal_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_PersonasPenal_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    idPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_Cliente_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_Cliente_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_Cliente_Personas_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Personas",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_Cliente_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "PersonasDomicilios",
                columns: table => new
                {
                    idPersonasDomicilios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPersona = table.Column<int>(type: "int", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<int>(type: "int", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasDomicilios", x => x.idPersonasDomicilios);
                    table.ForeignKey(
                        name: "FK_PersonasDomicilios_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_PersonasDomicilios_Personas_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Personas",
                        principalColumn: "idPersona");
                });

            migrationBuilder.CreateTable(
                name: "Plantillas",
                columns: table => new
                {
                    idPlantilla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    idPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idClientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteidCliente = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantillas", x => x.idPlantilla);
                    table.ForeignKey(
                        name: "FK_Plantillas_Cliente_ClienteidCliente",
                        column: x => x.ClienteidCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Plantillas_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_Plantillas_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_Plantillas_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_Plantillas_Personas_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Personas",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_Plantillas_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "PlantillasPenal",
                columns: table => new
                {
                    idPlantillaPenal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    idPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idClientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteidCliente = table.Column<int>(type: "int", nullable: true),
                    idPlantilla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantillaidPlantilla = table.Column<int>(type: "int", nullable: true),
                    idInformes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformeidInformes = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Delito = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Juzgado = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EstadoCausa = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Pruebas = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    RadiografiaExpediente = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    FechaDetencion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillasPenal", x => x.idPlantillaPenal);
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Cliente_ClienteidCliente",
                        column: x => x.ClienteidCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Informes_InformeidInformes",
                        column: x => x.InformeidInformes,
                        principalTable: "Informes",
                        principalColumn: "idInformes");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Personas_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Personas",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Plantillas_PlantillaidPlantilla",
                        column: x => x.PlantillaidPlantilla,
                        principalTable: "Plantillas",
                        principalColumn: "idPlantilla");
                    table.ForeignKey(
                        name: "FK_PlantillasPenal_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                });

            migrationBuilder.CreateTable(
                name: "PlantillasPenalTienenTestigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTestigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestigoidTestigo = table.Column<int>(type: "int", nullable: true),
                    idPaises = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisidPaises = table.Column<int>(type: "int", nullable: true),
                    idProvincias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaidProvincias = table.Column<int>(type: "int", nullable: true),
                    idLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadidLocalidades = table.Column<int>(type: "int", nullable: true),
                    idDomicilios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomicilioidDomicilios = table.Column<int>(type: "int", nullable: true),
                    idPersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaidPersona = table.Column<int>(type: "int", nullable: true),
                    idClientes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteidCliente = table.Column<int>(type: "int", nullable: true),
                    idPlantilla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantillaidPlantilla = table.Column<int>(type: "int", nullable: true),
                    idInformes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InformeidInformes = table.Column<int>(type: "int", nullable: true),
                    idPlantillaPenal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantillaPenalidPlantillaPenal = table.Column<int>(type: "int", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantillasPenalTienenTestigos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Cliente_ClienteidCliente",
                        column: x => x.ClienteidCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Domicilios_DomicilioidDomicilios",
                        column: x => x.DomicilioidDomicilios,
                        principalTable: "Domicilios",
                        principalColumn: "idDomicilios");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Informes_InformeidInformes",
                        column: x => x.InformeidInformes,
                        principalTable: "Informes",
                        principalColumn: "idInformes");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Localidades_LocalidadidLocalidades",
                        column: x => x.LocalidadidLocalidades,
                        principalTable: "Localidades",
                        principalColumn: "idLocalidades");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Paises_PaisidPaises",
                        column: x => x.PaisidPaises,
                        principalTable: "Paises",
                        principalColumn: "idPaises");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Personas_PersonaidPersona",
                        column: x => x.PersonaidPersona,
                        principalTable: "Personas",
                        principalColumn: "idPersona");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_PlantillasPenal_PlantillaPenalidPlantillaPenal",
                        column: x => x.PlantillaPenalidPlantillaPenal,
                        principalTable: "PlantillasPenal",
                        principalColumn: "idPlantillaPenal");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Plantillas_PlantillaidPlantilla",
                        column: x => x.PlantillaidPlantilla,
                        principalTable: "Plantillas",
                        principalColumn: "idPlantilla");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Provincias_ProvinciaidProvincias",
                        column: x => x.ProvinciaidProvincias,
                        principalTable: "Provincias",
                        principalColumn: "idProvincias");
                    table.ForeignKey(
                        name: "FK_PlantillasPenalTienenTestigos_Testigos_TestigoidTestigo",
                        column: x => x.TestigoidTestigo,
                        principalTable: "Testigos",
                        principalColumn: "idTestigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_DomicilioidDomicilios",
                table: "Cliente",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_LocalidadidLocalidades",
                table: "Cliente",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PaisidPaises",
                table: "Cliente",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PersonaidPersona",
                table: "Cliente",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ProvinciaidProvincias",
                table: "Cliente",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_LocalidadidLocalidades",
                table: "Domicilios",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_PaisidPaises",
                table: "Domicilios",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_ProvinciaidProvincias",
                table: "Domicilios",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_PaisidPaises",
                table: "Localidades",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaidProvincias",
                table: "Localidades",
                column: "ProvinciaidProvincias");

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
                name: "IX_Personas_DomicilioidDomicilios",
                table: "Personas",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_LocalidadidLocalidades",
                table: "Personas",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PaisidPaises",
                table: "Personas",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ProvinciaidProvincias",
                table: "Personas",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDomicilios_DomicilioidDomicilios",
                table: "PersonasDomicilios",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasDomicilios_PersonaidPersona",
                table: "PersonasDomicilios",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasPenal_DomicilioidDomicilios",
                table: "PersonasPenal",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasPenal_LocalidadidLocalidades",
                table: "PersonasPenal",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasPenal_PaisidPaises",
                table: "PersonasPenal",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasPenal_ProvinciaidProvincias",
                table: "PersonasPenal",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_ClienteidCliente",
                table: "Plantillas",
                column: "ClienteidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_DomicilioidDomicilios",
                table: "Plantillas",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_LocalidadidLocalidades",
                table: "Plantillas",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_PaisidPaises",
                table: "Plantillas",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_PersonaidPersona",
                table: "Plantillas",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Plantillas_ProvinciaidProvincias",
                table: "Plantillas",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_ClienteidCliente",
                table: "PlantillasPenal",
                column: "ClienteidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_DomicilioidDomicilios",
                table: "PlantillasPenal",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_InformeidInformes",
                table: "PlantillasPenal",
                column: "InformeidInformes");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_LocalidadidLocalidades",
                table: "PlantillasPenal",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_PaisidPaises",
                table: "PlantillasPenal",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_PersonaidPersona",
                table: "PlantillasPenal",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_PlantillaidPlantilla",
                table: "PlantillasPenal",
                column: "PlantillaidPlantilla");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenal_ProvinciaidProvincias",
                table: "PlantillasPenal",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_ClienteidCliente",
                table: "PlantillasPenalTienenTestigos",
                column: "ClienteidCliente");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_DomicilioidDomicilios",
                table: "PlantillasPenalTienenTestigos",
                column: "DomicilioidDomicilios");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_InformeidInformes",
                table: "PlantillasPenalTienenTestigos",
                column: "InformeidInformes");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_LocalidadidLocalidades",
                table: "PlantillasPenalTienenTestigos",
                column: "LocalidadidLocalidades");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_PaisidPaises",
                table: "PlantillasPenalTienenTestigos",
                column: "PaisidPaises");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_PersonaidPersona",
                table: "PlantillasPenalTienenTestigos",
                column: "PersonaidPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_PlantillaidPlantilla",
                table: "PlantillasPenalTienenTestigos",
                column: "PlantillaidPlantilla");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_PlantillaPenalidPlantillaPenal",
                table: "PlantillasPenalTienenTestigos",
                column: "PlantillaPenalidPlantillaPenal");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_ProvinciaidProvincias",
                table: "PlantillasPenalTienenTestigos",
                column: "ProvinciaidProvincias");

            migrationBuilder.CreateIndex(
                name: "IX_PlantillasPenalTienenTestigos_TestigoidTestigo",
                table: "PlantillasPenalTienenTestigos",
                column: "TestigoidTestigo");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_PaisidPaises",
                table: "Provincias",
                column: "PaisidPaises");

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
                name: "PersonasPenal");

            migrationBuilder.DropTable(
                name: "PlantillasPenalTienenTestigos");

            migrationBuilder.DropTable(
                name: "PlantillasPenal");

            migrationBuilder.DropTable(
                name: "Testigos");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "Plantillas");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}

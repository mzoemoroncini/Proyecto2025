using EstudioJuridico.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos
{
   

    public class AppDBContext : DbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<PersonaDomicilio> PersonasDomicilios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaPenal> PersonasPenal { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<PlantillaPenal> PlantillasPenal { get; set; }
        public DbSet<Informe> Informes { get; set; }
        public DbSet<PlantillaPenalTieneTestigo> PlantillasPenalTienenTestigos { get; set; }
        public DbSet<Testigo> Testigos { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {

        }

        //Aqui puedes configurar entidades y relaciones 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

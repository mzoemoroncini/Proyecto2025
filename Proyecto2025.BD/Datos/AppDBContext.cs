using EstudioJuridico.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos
{
   

    public class AppDBContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<PersonaDomicilio> PersonasDomicilios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaPenal> PersonasPenals { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<PlantillaPenal> PlantillasPenals { get; set; }
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
           modelBuilder.Entity<PersonaDomicilio>()
                .HasKey(a => new { a.PersonaID , a.DomicilioID });

            modelBuilder.Entity<PersonaDomicilio>()
                .HasOne(pd => pd.Personas)
                .WithMany(p => p.PersonaDomicilios)
                .HasForeignKey(pd => pd.PersonaID);

            modelBuilder.Entity<PersonaDomicilio>()
                .HasOne(pd => pd.Domicilios)
                .WithMany(d => d.PersonaDomicilios)
                .HasForeignKey(pd => pd.DomicilioID);



            modelBuilder.Entity<Domicilio>()
                .HasOne(d => d.Localidades)
                .WithMany(l => l.Domicilios)
                .HasForeignKey(d => d.LocalidadID);

            modelBuilder.Entity<Localidad>()
                .HasOne(l => l.Provincias)
                .WithMany(p => p.Localidades)
                .HasForeignKey(l => l.ProvinciaID);

            modelBuilder.Entity<Provincia>()
                .HasOne(p => p.Paises)
                .WithMany(pa => pa.Provincias)
                .HasForeignKey(p => p.PaisID);

            modelBuilder.Entity<PersonaPenal>()
                .HasOne(pp => pp.Personas)
                .WithMany(p => p.PersonaPenals)
                .HasForeignKey(pp => pp.PersonaId);

            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Personas)
                .WithMany(p => p.Clientes)
                .HasForeignKey(c => c.PersonasID);

            modelBuilder.Entity<Plantilla>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Plantillas)
                .HasForeignKey(p => p.ClienteId);

            modelBuilder.Entity<PlantillaPenal>()
                .HasOne(pp => pp.Informes)
                .WithMany(c => c.plantillaPenals)
                .HasForeignKey(pp => pp.InformeId);



            modelBuilder.Entity<PlantillaPenalTieneTestigo>()
                .HasKey(pt => new { pt.PlantillaPenalId, pt.TestigoId });

            modelBuilder.Entity<PlantillaPenalTieneTestigo>()
                .HasOne(pt => pt.PlantillaPenals)
                .WithMany(p => p.PlantillaPenalTieneTestigos)
                .HasForeignKey(pt => pt.PlantillaPenalId);

            modelBuilder.Entity<PlantillaPenalTieneTestigo>()
                .HasOne(pt => pt.Testigos)
                .WithMany(t => t.plantillaPenalTieneTestigos)
                .HasForeignKey(pt => pt.TestigoId);


        }
    }
}

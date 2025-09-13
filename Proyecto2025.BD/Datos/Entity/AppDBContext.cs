using EstudioJuridico.BD.Datos;
using Microsoft.EntityFrameworkCore;

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
   

    public class AppDBContext : DbContext
    {
        public DbSet<Caso> Casos { get; set; }
        public DbSet<CasoPersona> CasosPersona { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<MovimientoPersona> MovimientoPersonas { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaPlantilla> PersonaPlantillas { get; set; }
        public DbSet<PersonaDomicilio> PersonaDomicilios { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<PlantillaCaso> PlantillaCasos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Testigo> Testigos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EventoParticipante> EventoParticipantes { get; set; }
        public DbSet<TipoDocumentacion> TipoDocumentos { get; set; }
        public DbSet<Documentacion> Documentacions { get; set; }

       

        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            // Muchos a muchos
            

            // CasoPersona
            modelBuilder.Entity<CasoPersona>()
                .HasKey(cp => new { cp.CasoId, cp.PersonaId });
            modelBuilder.Entity<CasoPersona>()
                .HasOne(cp => cp.Casos)
                .WithMany(c => c.CasoPersonas)
                .HasForeignKey(cp => cp.CasoId);
            modelBuilder.Entity<CasoPersona>()
                .HasOne(cp => cp.Personas)
                .WithMany(p => p.CasoPersonas)
                .HasForeignKey(cp => cp.PersonaId);

            // PersonaDomicilio
            modelBuilder.Entity<PersonaDomicilio>()
                .HasKey(dp => new { dp.DomicilioID, dp.PersonaID });
            modelBuilder.Entity<PersonaDomicilio>()
                .HasOne(dp => dp.Domicilios)
                .WithMany()
                .HasForeignKey(dp => dp.DomicilioID);
            modelBuilder.Entity<PersonaDomicilio>()
                .HasOne(dp => dp.Personas)
                .WithMany(p => p.PersonaDomicilios)
                .HasForeignKey(dp => dp.PersonaID);

            // PersonaPlantilla
            modelBuilder.Entity<PersonaPlantilla>()
            .HasKey(pp => new { pp.PlantillaID, pp.PersonaID });
            modelBuilder.Entity<PersonaPlantilla>()
                .HasOne(pp => pp.Plantillas)
                .WithMany(p => p.PersonaPlantillas)
                .HasForeignKey(pp => pp.PlantillaID);   
            modelBuilder.Entity<PersonaPlantilla>()
                .HasOne(pp => pp.Personas)
                .WithMany(p => p.PersonaPlantillas)
                .HasForeignKey(pp => pp.PersonaID);

            // PlantillaCaso
            modelBuilder.Entity<PlantillaCaso>()
                .HasKey(pc => new { pc.PlantillaID, pc.CasoID });
            modelBuilder.Entity<PlantillaCaso>()
                .HasOne(pc => pc.Plantillas)
                .WithMany(p => p.PlantillaCasos)
                .HasForeignKey(pc => pc.PlantillaID);
            modelBuilder.Entity<PlantillaCaso>()
                .HasOne(pc => pc.Casos)
                .WithMany(c => c.PlantillaCasos)
                .HasForeignKey(pc => pc.CasoID);

            // EventoParticipante
            modelBuilder.Entity<EventoParticipante>()
                .HasKey(ep => ep.Id);
            modelBuilder.Entity<EventoParticipante>()
                .HasOne(ep => ep.Eventos)
                .WithMany(e => e.EventoParticipantes)
                .HasForeignKey(ep => ep.EventoId);
            modelBuilder.Entity<EventoParticipante>()
                .HasOne(ep => ep.Usuarios)
                .WithMany(u => u.EventoParticipantes)
                .HasForeignKey(ep => ep.UsuarioId);

            // ---------------------------
            // Relaciones uno a muchos
            // ---------------------------

            // Testigos
            modelBuilder.Entity<Testigo>()
                .HasOne(t => t.Caso)
                .WithMany(c => c.Testigos)
                .HasForeignKey(t => t.CasoId);

            // Movimientos
            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Casos)
                .WithMany(c => c.Movimientos)
                .HasForeignKey(m => m.CasoID);
            modelBuilder.Entity<Movimiento>()
                .HasOne(m => m.Personas)
                .WithMany()
                .HasForeignKey(m => m.PersonaID);

            // Eventos
            modelBuilder.Entity<Evento>()
                .HasOne(e => e.Casos)
                .WithMany(c => c.Eventos)
                .HasForeignKey(e => e.CasoId);

            // ---------------------------
            // Enums como string
            // ---------------------------
            modelBuilder.Entity<Caso>()
                .Property(c => c.Estado)
                .HasConversion<string>();
            modelBuilder.Entity<Caso>()
                .Property(c => c.Tipo)
                .HasConversion<string>();
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasConversion<string>();
            modelBuilder.Entity<Evento>()
                .Property(e => e.Estado)
                .HasConversion<string>();
            modelBuilder.Entity<Movimiento>()
                .Property(m => m.Tipo)
                .HasConversion<string>();
            modelBuilder.Entity<Plantilla>()
                .Property(p => p.Tipo)
                .HasConversion<string>();
        }
    }
}


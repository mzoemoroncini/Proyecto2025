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

        
    }
}

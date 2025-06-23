using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PersonaPenal
    {
        [Key]
        public int Id { get; set; }

        public int PlantillaPenals { get; set; }

        //recibo de la navegacion de persona que vendria a ser el id de persona para poder relacionarse 1 a muchos 
        public int PersonaId { get; set; }
        public required Persona? Personas { get; set; }

    }
}
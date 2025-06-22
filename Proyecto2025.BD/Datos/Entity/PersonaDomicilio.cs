using Proyecto2025.BD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PersonaDomicilio : EntityBase
    /*
Personas_idPersona INT
Domicilios_idDomicilios INT

     */
    {
        [Key]
        public int idPersonasDomicilios { get; set; }

        [Required]
        public int idPersona { get; set; }
        public Persona? Persona { get; set; }

        [Required]
        public int idDomicilios { get; set; }
        public Domicilio? Domicilio { get; set; }
    }
}

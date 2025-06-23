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
    public class Persona 
    {
      
        [Required(ErrorMessage = "El Pais, la Provincia, la Localidad y Domicilio son obligatorios")]

        [Key]
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "Telefono es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Telefono { get; set; }

        [Required(ErrorMessage = "DNI es obligatorio")]
        [MaxLength(45, ErrorMessage = "1 caracter mínimo")]
        public required int DNI { get; set; }

        [Required(ErrorMessage = "Mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "1 caracter mínimo")]
        public required string Mail { get; set; }

        [Required(ErrorMessage = "Indicar si pago la Tasa de Justicia o los Aportes")]
        public bool? TasaJusticia_Aportes { get; set; }

        //navegando la id de persona a personal penal con el nombre PersonaId
        public List<PersonaPenal>? PersonaPenals { get; set; } = new List<PersonaPenal>();

        // navegacion de persona a personasdomicilio 

        public List<PersonaDomicilio>? PersonaDomicilios { get; set; } = new List<PersonaDomicilio>();

        //navegacion del id a tabla cliente 
        public List<Cliente>? Clientes { get; set; } = new List<Cliente>(); 
    }
}

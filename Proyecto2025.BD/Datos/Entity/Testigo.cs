using Proyecto2025.BD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class Testigo : EntityBase
    {
        [Key]
        public int idTestigo { get; set; }
        [Required(ErrorMessage = "Nombre del testigo es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NombreTestigo { get; set; }
    }
}
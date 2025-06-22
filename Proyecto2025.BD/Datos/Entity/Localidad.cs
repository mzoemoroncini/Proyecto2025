using Microsoft.EntityFrameworkCore;
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
    [Index(nameof(Codigo), Name = "Localidad_Codigo_UQ", IsUnique = true)]

    public class Localidad : EntityBase
    {
        [Required(ErrorMessage = "El Pais y la Provincia son obligatorios")]

        [Key]
        public int idLocalidades { get; set; }

        public required string idPaises { get; set; }
        public Pais? Pais { get; set; }
        public required string idProvincias { get; set; }
        public Provincia? Provincia { get; set; }

        [Required(ErrorMessage = "El Codigo es obligatorio")]
        [MaxLength(3, ErrorMessage = "1 caracter mínimo")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre de la localidad es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NomLocalidad { get; set; }

    }
}

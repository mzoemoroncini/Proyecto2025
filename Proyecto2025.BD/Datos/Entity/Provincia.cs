using EstudioJuridico.BD.Datos.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos.Entity
{
    [Index(nameof(Codigo), Name = "Provincia_Codigo_UQ", IsUnique = true)]

    public class Provincia : EntityBase
    {
        [Required(ErrorMessage = "El Pais es obligatorio")]
        [Key]
        public int idProvincias { get; set; }

        public required string idPaises { get; set; }
        public Pais? Pais { get; set;}

        [Required(ErrorMessage = "El Codigo es obligatorio")]
        [MaxLength(2, ErrorMessage = "1 caracteres máximo")]
        public required string Codigo{ get; set; }

        [Required(ErrorMessage = "El Nombre de la provincia es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NomProvincia{ get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System;
using EstudioJuridico.BD.Datos.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{

    [Index(nameof(Codigo), Name = "Pais_Codigo_UQ", IsUnique = true)]
    // [Index(nameof(idPaises), Name = "Pais_idPaises_UQ", IsUnique = true)]

    public class Pais : BaseEntity
    {
        

        [Required(ErrorMessage = "El cód. Internacional es obligatorio")]
        [MaxLength(3, ErrorMessage = "3 caracteres máximo")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El Nombre del Pais es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NomPais { get; set; }

        public List<Provincia>? Provincias { get; set; } = new List<Provincia>();
    }
}

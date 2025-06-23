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

    public class Provincia 
    {
        
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Codigo es obligatorio")]
        [MaxLength(2, ErrorMessage = "1 caracteres máximo")]
        public required string Codigo{ get; set; }

        [Required(ErrorMessage = "El Nombre de la provincia es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NomProvincia{ get; set; }

        //la navegacion del id provincia que sera enviada a la tabla localidades
        public List<Localidad>? Localidades { get; set; } = new List<Localidad>();

        // fk de pais
        public int PaisID { get; set; }
        public Pais? Paises { get; set; }

    }
}

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
    [Index(nameof(Codigo), Name = "Provincia_Codigo_UQ", IsUnique = true)]

    public class Provincia : DbContext
    {
        
       
        [Required(ErrorMessage = "El Codigo es obligatorio")]
        [MaxLength(2, ErrorMessage = "1 caracteres máximo")]
        public required string Codigo{ get; set; }

        [Required(ErrorMessage = "El Nombre de la provincia es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NombreProvincia{ get; set; }

        //navegacion
        public List<Localidad>? Localidades { get; set; } = new List<Localidad>();

        // fk
        public int PaisID { get; set; }
        public Pais? Paises { get; set; }

    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EstudioJuridico.BD.Datos
{
    public class Domicilio : BaseEntity
    {
       // [Required(ErrorMessage = "El Pais, la Provincia y Localidad son obligatorios")]

        [Required(ErrorMessage = "La Calle es obligatoria")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Calle { get; set; }

        [Required(ErrorMessage = "El Número es obligatorio")]
        [MaxLength(45, ErrorMessage = "1 caracter mínimo")]
        public required string Numero { get; set; }

        [Required(ErrorMessage = "El barrio es obligatorio")]
        [MaxLength(45, ErrorMessage = "1 caracter mínimo")]
        public required string Barrio { get; set; }

        [Required(ErrorMessage = "El Piso es obligatorio")]
        [MaxLength(200, ErrorMessage = "1 caracter mínimo")]
        public required string Piso { get; set; }

        [Required(ErrorMessage = "El Departamento es obligatorio")]
        [MaxLength(45, ErrorMessage = "1 caracter mínimo")]
        public required string Departamento { get; set; }


        // claves foraneas
        public int LocalidadID { get; set; }
        public Localidad? Localidades { get; set; }


        // navegacion
        public List<PersonaDomicilio>? PersonaDomicilios { get; set; } = new List<PersonaDomicilio>();

    }
}

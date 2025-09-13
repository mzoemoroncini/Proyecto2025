using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Testigo : DBContext
    {
       
        [Required(ErrorMessage = "Nombre del testigo es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string NombreTestigo { get; set; }

        //fk
        public int? CasoId { get; set; }
        public Caso? Caso { get; set; }


        //navegacion
    }
}
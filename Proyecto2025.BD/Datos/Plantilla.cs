using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    
    public class Plantilla : DBContext
    {

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es obligatoria")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public required DateTime FechaCreacion { get; set; }

        public enum Tipo
        {
            Cliente,
            Penal
        }
        //fk

        //navegacion hacia la tabla plantilla penal 
        public List<PersonaPlantilla>? PersonaPlantillas { get; set; }
        public List<PlantillaCaso>? PlantillaCasos { get; set; }




    }
}

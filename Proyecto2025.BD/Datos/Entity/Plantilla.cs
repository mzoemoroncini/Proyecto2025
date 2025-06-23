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
    public enum Tipo
    {
        Cliente = 1,
        Penal = 2
    }
    public class Plantilla 
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Descripción es obligatoria")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public required DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Tipo de plantilla es obligatoria")]
        [MaxLength(2, ErrorMessage = "1 caracter mínimo")]
        public required Tipo Tipo{ get; set; }

        //fk de cliente 
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }  
        
        //navegacion hacia la tabla plantilla penal 
        public List<PlantillaPenal> plantillaPenals { get; set; } = new List<PlantillaPenal>();

        
        

    }
}

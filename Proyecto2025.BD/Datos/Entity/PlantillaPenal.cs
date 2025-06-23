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
  
    public class PlantillaPenal 
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El Nombre del imputado es obligatorio")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El Delito del imputado es obligatorio")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string Delito { get; set; }

        [Required(ErrorMessage = "El Juzgado del imputado es obligatorio")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string Juzgado { get; set; }

        [Required(ErrorMessage = "El Estado de la causa del imputado es obligatorio")]
        [MaxLength(300, ErrorMessage = "1 caracter mínimo")]
        public required string EstadoCausa { get; set; }

        [Required(ErrorMessage = "Las pruebas de la causa del imputado es obligatorio")]
        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public required string Pruebas { get; set; }

        [Required(ErrorMessage = "Las Radiogradia del expediente del imputado es obligatorio")]
        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public required string RadiografiaExpediente { get; set; }

        [Required(ErrorMessage = "La ubicacion del imputado es obligatorio")]
        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public required string Ubicacion { get; set; }

        [DataType(DataType.Date)]
        public required DateTime FechaDetencion { get; set; }

        public int InformeId { get; set; }
        public Informe? Informes { get; set; }

        public List<PlantillaPenalTieneTestigo> PlantillaPenalTieneTestigos { get; set; } = new List<PlantillaPenalTieneTestigo>();    
    }
}
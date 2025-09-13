using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Evento : DBContext
    {
        [Required(ErrorMessage = "El titulo es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Fecha de Inicio es obligatoria")]
        public DateOnly Inicio { get; set; }
        public DateOnly Fin { get; set; }

        public enum EstadoEvento
        {
            Pendiente,
            Completado,
            Cancelado
        }
        [Required(ErrorMessage = "La ubicacion es obligatoria")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]

        public string Ubicacion { get; set; }

        //fk
        public int CasoId { get; set; }
        public Caso? Casos { get; set; }

        // navegacion
        public List<EventoParticipante>? EventoParticipantes { get; set; } 
    }
}

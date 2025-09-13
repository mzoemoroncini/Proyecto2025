using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class EventoParticipante : DBContext
    {
        [Required(ErrorMessage = "El Rol es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Rol { get; set; }


        //fk
        public int EventoId { get; set; }
        public Evento? Eventos { get; set; }

        public int PersonaId { get; set; }
        public Persona? Personas { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuarios { get; set; }
    }
}

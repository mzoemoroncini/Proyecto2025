using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Usuario : DBContext
    {
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Mail es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Mail { get; set; }

        public enum Rol
        {
            Administrador,
            Abogado,
            Secretaria
        }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Password { get; set; }


        //fk
        public int PersonaId { get; set; }
        public Persona? Personas { get; set; }

        //navegacion
        public List<EventoParticipante>? EventoParticipantes { get; set; }
    }
}

using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Persona : BaseEntity
    {
     
       
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "Telefono es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public required string Telefono { get; set; }

        [Required(ErrorMessage = "DNI es obligatorio")]
        [MaxLength(45, ErrorMessage = "1 caracter mínimo")]
        public required int DNI { get; set; }

        [Required(ErrorMessage = "Mail es obligatorio")]
        [MaxLength(150, ErrorMessage = "1 caracter mínimo")]
        public required string Mail { get; set; }

        [Required(ErrorMessage = "Indicar si pago la Tasa de Justicia o los Aportes")]
        public bool? TasaJusticia_Aportes { get; set; }



        // navegacion 

        public List<CasoPersona>? CasoPersonas { get; set; }
        public List<PersonaDomicilio>? PersonaDomicilios { get; set; }
        public List<EventoParticipante>? EventoParticipantes { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
        public List<PersonaPlantilla>? PersonaPlantillas { get; set; }
        public List<Usuario>? Usuarios { get; set; }


    }
    }

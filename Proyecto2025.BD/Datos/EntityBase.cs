using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos
{
    public class EntityBase
    {
       public int Id { get; set; }

        [Required(ErrorMessage = "El Estado de Registro es obligatorio")]

        public ENUMEstadoRegistro EstadoRegistro { get; set; } = ENUMEstadoRegistro.EnGrabacion;
        public string Observacion { get; set; } = string.Empty;



    }
}

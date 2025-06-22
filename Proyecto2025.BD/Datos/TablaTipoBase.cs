using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2025.BD.Datos
{
    public class TablaTipoBase : EntityBase
    {
        [Required(ErrorMessage = "El cód. es obligatorio")]
        [MaxLength(3, ErrorMessage = "1 caracteres máximo")]
        public required string Codigo { get; set; }

        [Required(ErrorMessage = "El Tipo es obligatorio")]
        [MaxLength(20, ErrorMessage = "1 caracteres máximo")]
        public required string Tipo { get; set; }


        [MaxLength(100, ErrorMessage = "1 caracteres máximo")]
        public required string Descripcion { get; set; } = string.Empty;
    }
}

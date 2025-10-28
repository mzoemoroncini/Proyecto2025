using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Shared.DTO
{
    public class DocumentacionDTO : BaseEntityDTO
    {
        public int CasoId { get; set; }
        public int TipoDocumentacionId { get; set; }

        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [MaxLength(10000)]
        public string? ArchivoUrl { get; set; }
    }
    
}

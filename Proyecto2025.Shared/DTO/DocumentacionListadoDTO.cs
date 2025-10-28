using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Shared.DTO
{
    public class DocumentacionListadoDTO : BaseEntityDTO
    {

       
        public string ArchivoUrl { get; set; }
        
        public string DatosDocumento { get; set; } =  "";
       

    }
}

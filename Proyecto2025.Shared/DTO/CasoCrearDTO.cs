using Proyecto2025.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.Shared.DTO
{
    public class CasoCrearDTO
    {
        public int Id { get; set; }
        public int NumeroExpediente { get; set; }
        public DateOnly FechaInicio { get; set; }
        public string Estado { get; set; } =  "";
         public string Tipo { get; set; } = "";

    }
}

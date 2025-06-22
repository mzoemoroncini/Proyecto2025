using Proyecto2025.BD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public enum TipoInforme
    {
        Pericial = 1,
        Psicologico = 2,
        CamaraGessell = 3,
        PeritoDeControl = 4,
        Otro = 5
    }
    public class Informe : EntityBase
    {
        [Key]
        public int idInformes { get; set; }

        [Required(ErrorMessage = "El tipo de informe es obligatoria")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public TipoInforme Tipo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [MaxLength(10000, ErrorMessage = "1 caracter mínimo")]
        public required string Descripcion { get; set; }

      
        [MaxLength(500)]
        public required string ArchivoUrl { get; set; }
    }
}

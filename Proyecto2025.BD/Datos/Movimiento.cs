using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Movimiento : DBContext
    {
        public enum Tipo
        {
            Honorario,
            Gasto
        }
        [Required(ErrorMessage = "Concepto es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Monto es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Comprobante es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public string MedioPago { get; set; }
        public string Comprobante { get; set; }


        //fk
        public int CasoID { get; set; }
        public Caso? Casos { get; set; }

        public int PersonaID { get; set; }
        public Persona? Personas { get; set; }
    }
}

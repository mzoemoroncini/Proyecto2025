using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class Caso : BaseEntity
        {
        

        [Required(ErrorMessage = "El numero de expediente es obligatorio")]
        [MaxLength(100, ErrorMessage = "1 caracter mínimo")]
        public int NumeroExpediente { get; set; }

        [DataType(DataType.Date)]
        public DateOnly FechaInicio { get; set; }
       
        public EstadoCaso Estado { get; set; }
        public string? Descripcion { get; set; }
        
        public TipoCaso Tipo { get; set; }
        // navegacion 
        public List<CasoPersona>? CasoPersonas { get; set; }
        public List<Documentacion>? Documentacions { get; set; }
        public List<Evento>? Eventos { get; set; }
        public List<Movimiento>? Movimientos { get; set; }
        public List<PlantillaCaso>? PlantillaCasos { get; set; }
        public List<Testigo>? Testigos { get; set; }

        
    }
    public enum EstadoCaso
    {
        Abierto,
        Cerrado,
        EnProgreso,
        EnEspera
    }
    public enum TipoCaso
    {
        Civil,
        Penal,
        Laboral,
        Familiar,
        Comercial
    }
}

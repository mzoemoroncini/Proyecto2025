using EstudioJuridico.BD.Datos;

namespace Proyecto2025.Server.Controllers
{
    public class CasoCrearDTO
    {
        public int Id { get; set; } 
        public int NumeroExpediente { get; set; }
        public DateOnly FechaInicio { get; set; }
        public EstadoCaso Estado { get; set; }
        public string? Descripcion { get; set; }
        public TipoCaso Tipo { get; set; }
    }
}

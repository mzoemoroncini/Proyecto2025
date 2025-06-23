using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PlantillaPenalTieneTestigo
    {
        
        public int PlantillaPenalId { get; set; }
        public PlantillaPenal? PlantillaPenals { get; set; }

        public int TestigoId { get; set; }
        public Testigo? Testigos { get; set; }




    }
}
/*Testigos_idTestigos INT
Plantilla_penal_idPenal INT

 */
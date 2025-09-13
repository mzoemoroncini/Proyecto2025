using EstudioJuridico.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class PlantillaCaso : BaseEntity
    {

        //fk
        public int PlantillaID { get; set; }
        public Plantilla? Plantillas { get; set; }
        public int CasoID { get; set; }
        public Caso? Casos { get; set; }
    }
}

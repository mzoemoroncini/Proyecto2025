using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos
{
    public class PersonaPlantilla
    {

        //fk
        public int PersonaID { get; set; }
        public PersonaPlantilla? PersonaPlantillas { get; set; }

        public int PlantillaID { get; set; }
        public Plantilla? Plantillas { get; set; }

    }
}

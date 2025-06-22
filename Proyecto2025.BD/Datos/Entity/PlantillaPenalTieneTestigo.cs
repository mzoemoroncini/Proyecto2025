using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PlantillaPenalTieneTestigo : EntityBase
    {
        public required string idTestigo { get; set; }
        public Testigo? Testigo { get; set; }

        public required string idPaises { get; set; }
        public Pais? Pais { get; set; }
        public required string idProvincias { get; set; }
        public Provincia? Provincia { get; set; }
        public required string idLocalidad { get; set; }
        public Localidad? Localidad { get; set; }
        public required string idDomicilios { get; set; }
        public Domicilio? Domicilio { get; set; }
        public required string idPersona { get; set; }
        public Persona? Persona { get; set; }
        public required string idClientes { get; set; }
        public Cliente? Cliente { get; set; }
        public required string idPlantilla { get; set; }
        public Plantilla? Plantilla { get; set; }
        public required string idInformes { get; set; }
        public Informe? Informe { get; set; }
        public required string idPlantillaPenal { get; set; }
        public PlantillaPenal? PlantillaPenal { get; set; }

    }
}
/*Testigos_idTestigos INT
Plantilla_penal_idPenal INT

 */
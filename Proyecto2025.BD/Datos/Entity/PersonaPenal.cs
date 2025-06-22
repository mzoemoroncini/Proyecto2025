using Proyecto2025.BD.Datos;
using Proyecto2025.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PersonaPenal : EntityBase
    {
        [Key]
        public int idPersonaPenal { get; set; }
        public required string idPaises { get; set; }
        public Pais? Pais { get; set; }
        public required string idProvincias { get; set; }
        public Provincia? Provincia { get; set; }
        public required string idLocalidad { get; set; }
        public Localidad? Localidad { get; set; }
        public required string idDomicilios { get; set; }
        public Domicilio? Domicilio { get; set; }
    }
}
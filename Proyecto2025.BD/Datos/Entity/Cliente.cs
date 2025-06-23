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
    public class Cliente 
    {
  
        [Key]
       public int Id { get; set; }

        // fk de persona 
        public int PersonasID { get; set; }
        public Persona? Personas { get; set; }

        public List<Plantilla> Plantillas { get; set; } = new List<Plantilla>();
    }
}

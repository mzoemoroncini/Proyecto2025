using Proyecto2025.BD.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudioJuridico.BD.Datos.Entity
{
    public class PersonaDomicilio 

     
    {
        // fk de personas 
       public int PersonaID { get; set; }
        public Persona? Personas { get; set; } 

        //fk de domicilio 
        public int DomicilioID { get; set; }
        public Domicilio? Domicilios { get; set; }
    }
}
